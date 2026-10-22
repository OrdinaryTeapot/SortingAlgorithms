using ClosedXML.Excel;
using ScottPlot.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace SortingAlgorithms
{
    public partial class Form1 : Form
    {
        // Данные последнего расчёта (нужны, чтобы заново проиграть анимацию)
        int[] lastData = null;
        bool lastAsc = true;

        // Какие алгоритмы участвовали в последнем расчёте
        bool ranBubble = false;
        bool ranInsertion = false;
        bool ranShaker = false;
        bool ranQuick = false;
        bool ranBogo = false;

        // BOGO работает только для небольших массивов
        const int MaxBogoSize = 10;

        // Для массивов больше этого размера медленные сортировки (O(n^2)) отключаются
        const int MaxSlowSize = 30000;

        // Если элементов больше этого числа, анимация не показывается
        const int MaxAnimationSize = 1000;

        // Отсортированный массив последнего расчёта (для сохранения в таблицу)
        int[] lastSorted = null;

        // Счётчик итераций текущей сортировки
        int iterations = 0;

        // Рисуем не каждый шаг, а каждый drawEvery-й (чтобы анимация на больших массивах не тянулась)
        int drawEvery = 1;
        int stepCounter = 0;

        // true, если во время анимации нажали "Очистить" - сортировки должны остановиться
        bool stopRequested = false;

        // true, пока идёт анимация (чтобы не запустить вторую одновременно)
        bool isBusy = false;

        public Form1()
        {
            InitializeComponent();

            dataGridView1.Columns.Add("ColumnName", "Данные");
        }

        private void рассчитатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            // 1. Читаем данные из таблицы
            List<int> dataInput = new List<int>();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                var cellValue = row.Cells[0].Value;

                if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue.ToString()))
                {
                    if (int.TryParse(cellValue.ToString(), out int number))
                    {
                        dataInput.Add(number);
                    }
                    else
                    {
                        MessageBox.Show($"Ошибка: в строке {row.Index + 1} введено не целое число!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
            }

            int[] data = dataInput.ToArray();

            // 2. Проверки
            if (data.Length == 0)
            {
                MessageBox.Show("Введите данные для сортировки!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ascCB.Checked && descCB.Checked)
            {
                MessageBox.Show("Выберите одно направление сортировки!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ascCB.Checked && !descCB.Checked)
            {
                MessageBox.Show("Выберите направление сортировки!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool asc = ascCB.Checked; // true - по возрастанию, false - по убыванию

            // Сбрасываем отметки о прошлом расчёте
            lastSorted = null;
            ranBubble = false;
            ranInsertion = false;
            ranShaker = false;
            ranQuick = false;
            ranBogo = false;

            // Снимаем галочки с алгоритмов, которые слишком медленные для такого массива
            if (data.Length > MaxBogoSize && bogoCB.Checked)
            {
                bogoCB.Checked = false;
                bogoLabel.Text = "BOGO сортировка пропущена: элементов больше " + MaxBogoSize;
            }

            if (data.Length > MaxSlowSize)
            {
                if (bubbleCB.Checked)
                {
                    bubbleCB.Checked = false;
                    bubbleLabel.Text = "Пузырьковая сортировка пропущена: элементов больше " + MaxSlowSize;
                }
                if (insertionCB.Checked)
                {
                    insertionCB.Checked = false;
                    insertionLabel.Text = "Сортировка вставками пропущена: элементов больше " + MaxSlowSize;
                }
                if (shakerCB.Checked)
                {
                    shakerCB.Checked = false;
                    shakerLabel.Text = "Шейкерная сортировка пропущена: элементов больше " + MaxSlowSize;
                }
            }

            // Если после этого ни один алгоритм не выбран 
            if (!bubbleCB.Checked && !insertionCB.Checked && !shakerCB.Checked && !quickCB.Checked && !bogoCB.Checked)
            {
                MessageBox.Show("Выберите хотя бы один алгоритм сортировки!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Для самого быстрого метода
            double bestTime = -1;
            string bestName = "";
            Label bestLabel = null; // label самой быстрой сортировки

            // Для рассчёта времени сортировки
            Stopwatch sw = new Stopwatch();

            // 3. Пузырьковая
            if (bubbleCB.Checked)
            {
                int[] a = CopyArray(data);
                iterations = 0;
                sw.Reset();
                sw.Start();
                BubbleSort(a, asc, null);
                sw.Stop();
                double time = sw.Elapsed.TotalMilliseconds;

                bubbleLabel.Text = "Пузырьковая сортировка: " + time.ToString("F4") + " мс\nИтераций: " + iterations + "\n" + ArrayToString(a);
                ranBubble = true;
                lastSorted = a; // запоминаем отсортированный массив

                if (bestTime == -1 || time < bestTime)
                {
                    bestTime = time;
                    bestName = "Пузырьковая";
                    bestLabel = bubbleLabel;
                }
            }

            // 4. Вставками
            if (insertionCB.Checked)
            {
                int[] a = CopyArray(data);
                iterations = 0;
                sw.Reset();
                sw.Start();
                InsertionSort(a, asc, null);
                sw.Stop();
                double time = sw.Elapsed.TotalMilliseconds;

                insertionLabel.Text = "Сортировка вставками: " + time.ToString("F4") + " мс\nИтераций: " + iterations + "\n" + ArrayToString(a);
                ranInsertion = true;
                lastSorted = a; // запоминаем отсортированный массив

                if (bestTime == -1 || time < bestTime)
                {
                    bestTime = time;
                    bestName = "Вставками";
                    bestLabel = insertionLabel;
                }
            }

            // 5. Шейкерная
            if (shakerCB.Checked)
            {
                int[] a = CopyArray(data);
                iterations = 0;
                sw.Reset();
                sw.Start();
                ShakerSort(a, asc, null);
                sw.Stop();
                double time = sw.Elapsed.TotalMilliseconds;

                shakerLabel.Text = "Шейкерная сортировка: " + time.ToString("F4") + " мс\nИтераций: " + iterations + "\n" + ArrayToString(a);
                ranShaker = true;
                lastSorted = a; // запоминаем отсортированный массив

                if (bestTime == -1 || time < bestTime)
                {
                    bestTime = time;
                    bestName = "Шейкерная";
                    bestLabel = shakerLabel;
                }
            }

            // 6. Быстрая
            if (quickCB.Checked)
            {
                int[] a = CopyArray(data);
                iterations = 0;
                sw.Reset();
                sw.Start();
                QuickSort(a, 0, a.Length - 1, asc, null);
                sw.Stop();
                double time = sw.Elapsed.TotalMilliseconds;

                quickLabel.Text = "Быстрая сортировка: " + time.ToString("F4") + " мс\nИтераций: " + iterations + "\n" + ArrayToString(a);
                ranQuick = true;
                lastSorted = a; // запоминаем отсортированный массив

                if (bestTime == -1 || time < bestTime)
                {
                    bestTime = time;
                    bestName = "Быстрая";
                    bestLabel = quickLabel;
                }
            }

            // 7. BOGO
            if (bogoCB.Checked)
            {
                if (data.Length > 10)
                {
                    MessageBox.Show("BOGO сортировка работает только для массивов до 10 элементов!",
                                    "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    int[] a = CopyArray(data);
                    iterations = 0;
                    sw.Reset();
                    sw.Start();
                    bool ok = BogoSort(a, asc, null);
                    sw.Stop();
                    double time = sw.Elapsed.TotalMilliseconds;

                    if (ok)
                    {
                        bogoLabel.Text = "BOGO сортировка: " + time.ToString("F4") + " мс\nИтераций: " + iterations + "\n" + ArrayToString(a);
                        ranBogo = true;
                        lastSorted = a; // запоминаем отсортированный массив

                        if (bestTime == -1 || time < bestTime)
                        {
                            bestTime = time;
                            bestName = "BOGO";
                            bestLabel = bogoLabel;
                        }
                    }
                    else
                    {
                        bogoLabel.Text = "BOGO сортировка не успела отсортировать массив";
                    }
                }
            }

            // 8. Отмечаем самую быструю сортировку в её label
            if (bestLabel != null)
            {
                bestLabel.Text = bestLabel.Text + "\nСамая быстрая сортировка!";
            }

            // 9. Запоминаем данные для повтора и запускаем анимацию
            lastData = CopyArray(data);
            lastAsc = asc;

            if (data.Length > MaxAnimationSize)
            {
                // слишком много элементов - анимацию не рисуем
                ClearPlots();
                MessageBox.Show("Элементов больше " + MaxAnimationSize + ", поэтому анимация сортировки не показывается.\n" +
                                "Отсортированный результат можно скачать в Excel (кнопка \"Скачать\" в меню).",
                                "Анимация отключена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                PlayAnimation();
            }
        }

        // Кнопки повторной анимации
        private void bubbleReplayButton_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            if (!ranBubble)
            {
                MessageBox.Show("Сначала рассчитайте пузырьковую сортировку!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsTooBigForAnimation()) return;

            StartPlay();
            AnimateBubble();
            EndPlay();
        }

        private void insertionReplayButton_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            if (!ranInsertion)
            {
                MessageBox.Show("Сначала рассчитайте сортировку вставками!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsTooBigForAnimation()) return;

            StartPlay();
            AnimateInsertion();
            EndPlay();
        }

        private void shakerReplayButton_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            if (!ranShaker)
            {
                MessageBox.Show("Сначала рассчитайте шейкерную сортировку!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsTooBigForAnimation()) return;

            StartPlay();
            AnimateShaker();
            EndPlay();
        }

        private void quickReplayButton_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            if (!ranQuick)
            {
                MessageBox.Show("Сначала рассчитайте быструю сортировку!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsTooBigForAnimation()) return;

            StartPlay();
            AnimateQuick();
            EndPlay();
        }

        private void bogoReplayButton_Click(object sender, EventArgs e)
        {
            if (isBusy) return;
            if (!ranBogo)
            {
                MessageBox.Show("Сначала рассчитайте BOGO сортировку!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (IsTooBigForAnimation()) return;

            StartPlay();
            AnimateBogo();
            EndPlay();
        }

        // Кнопка меню "Загрузить из файла": читает числа из Excel (.xlsx) в таблицу
        private void загрузитьИзФайлаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title = "Выберите файл Excel";
            dialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            List<int> numbers = new List<int>();
            int skipped = 0; // сколько ячеек пропущено (не целые числа, заголовки и т.д.)

            try
            {
                using (XLWorkbook workbook = new XLWorkbook(dialog.FileName))
                {
                    // берём первый лист книги
                    IXLWorksheet sheet = workbook.Worksheet(1);
                    IXLRange range = sheet.RangeUsed();

                    if (range == null)
                    {
                        MessageBox.Show("Файл пустой!", "Внимание",
                                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    foreach (IXLCell cell in range.Cells())
                    {
                        if (cell.IsEmpty()) continue;

                        if (cell.DataType == XLDataType.Number)
                        {
                            double value = cell.GetDouble();

                            // подходит только целое число в пределах int
                            if (value == Math.Floor(value) && value >= int.MinValue && value <= int.MaxValue)
                            {
                                numbers.Add((int)value);
                            }
                            else
                            {
                                skipped++;
                            }
                        }
                        else
                        {
                            // число, записанное в Excel как текст
                            if (int.TryParse(cell.GetString(), out int number))
                            {
                                numbers.Add(number);
                            }
                            else
                            {
                                skipped++;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось прочитать файл (возможно, он открыт):\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (numbers.Count == 0)
            {
                MessageBox.Show("В файле не найдено целых чисел!", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // заполняем таблицу
            dataGridView1.Rows.Clear();

            for (int i = 0; i < numbers.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = numbers[i];
            }

            if (skipped > 0)
            {
                MessageBox.Show("Загружено чисел: " + numbers.Count + "\nПропущено ячеек (не целые числа или текст): " + skipped,
                                "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Кнопка меню "Скачать": сохраняет отсортированный массив в Excel (.xlsx)
        private void скачатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            if (lastSorted == null)
            {
                MessageBox.Show("Сначала выполните сортировку (кнопка \"Рассчитать\")!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Сохранить отсортированный массив";
            dialog.Filter = "Файлы Excel (*.xlsx)|*.xlsx";
            dialog.FileName = "Отсортированный массив.xlsx";

            if (dialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                using (XLWorkbook workbook = new XLWorkbook())
                {
                    IXLWorksheet sheet = workbook.Worksheets.Add("Результат");

                    // заголовок в первой строке
                    sheet.Cell(1, 1).Value = "Отсортированные данные";

                    // числа начиная со второй строки
                    for (int i = 0; i < lastSorted.Length; i++)
                    {
                        sheet.Cell(i + 2, 1).Value = lastSorted[i];
                    }

                    sheet.Column(1).AdjustToContents();

                    workbook.SaveAs(dialog.FileName);
                }

                MessageBox.Show("Файл сохранён!", "Готово",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить файл (возможно, он открыт в Excel):\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Кнопка меню "Загрузить по ссылке": читает числа из таблицы Google Sheets
        // (таблица должна быть открыта для всех, у кого есть ссылка)
        private async void загрузитьПоСсылкеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            // 1. Спрашиваем ссылку (всплывает окно с полем ввода для ссылки)
            string link = AskForText("Загрузка из Google Sheets", "Вставьте ссылку на таблицу Google Sheets:");

            if (string.IsNullOrWhiteSpace(link)) return;

            link = link.Trim();

            // 2. Достаём из ссылки id таблицы и номер листа (gid)
            Match idMatch = Regex.Match(link, @"/spreadsheets/d/([a-zA-Z0-9_-]+)");
            if (!idMatch.Success)
            {
                MessageBox.Show("Это не похоже на ссылку на Google Sheets!",
                                "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string id = idMatch.Groups[1].Value;

            // Если в ссылке есть номер листа (gid) - берём его, иначе Google отдаст первый лист.
            // (Нельзя подставлять gid=0 "по умолчанию": у многих таблиц первый лист имеет другой gid)
            string gidPart = "";
            Match gidMatch = Regex.Match(link, @"[#&?]gid=([0-9]+)");
            if (gidMatch.Success)
            {
                gidPart = "&gid=" + gidMatch.Groups[1].Value;
            }

            // ссылка для скачивания листа в формате CSV
            string csvUrl = "https://docs.google.com/spreadsheets/d/" + id + "/export?format=csv" + gidPart;

            // 3. Скачиваем
            string text = "";
            isBusy = true; // пока идёт загрузка, другие кнопки не работают

            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                using (HttpClient client = new HttpClient())
                {
                    text = await client.GetStringAsync(csvUrl);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось скачать таблицу.\n" +
                                "Проверьте интернет и то, что доступ к таблице открыт по ссылке.\n\n" + ex.Message,
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                isBusy = false;
            }

            // если таблица закрыта, Google присылает страницу входа вместо данных
            if (text.Contains("<html") || text.Contains("<!DOCTYPE"))
            {
                MessageBox.Show("Таблица закрыта. Откройте доступ: Настройки доступа -> \"Все, у кого есть ссылка\" (читатель).",
                                "Нет доступа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Разбираем текст: строки, в строках ячейки через запятую
            List<int> numbers = new List<int>();
            int skipped = 0;

            string[] lines = text.Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] cells = lines[i].Split(new char[] { ',', ';' });

                for (int j = 0; j < cells.Length; j++)
                {
                    string cell = cells[j].Trim(new char[] { '"', ' ', '\r' });

                    if (cell == "") continue;

                    if (int.TryParse(cell, out int number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        skipped++;
                    }
                }
            }

            if (numbers.Count == 0)
            {
                MessageBox.Show("В таблице не найдено целых чисел!", "Внимание",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 5. Заполняем таблицу
            dataGridView1.Rows.Clear();

            for (int i = 0; i < numbers.Count; i++)
            {
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = numbers[i];
            }

            if (skipped > 0)
            {
                MessageBox.Show("Загружено чисел: " + numbers.Count + "\nПропущено ячеек (не целые числа или текст): " + skipped,
                                "Загрузка завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Маленькое окно с полем ввода текста. Возвращает введённый текст или null, если нажали "Отмена"
        private string AskForText(string title, string prompt)
        {
            using (Form form = new Form())
            {
                form.Text = title;
                form.FormBorderStyle = FormBorderStyle.FixedDialog;
                form.StartPosition = FormStartPosition.CenterParent;
                form.MinimizeBox = false;
                form.MaximizeBox = false;
                form.ClientSize = new Size(500, 110);

                Label label = new Label();
                label.Text = prompt;
                label.Location = new Point(10, 10);
                label.Size = new Size(480, 20);

                TextBox textBox = new TextBox();
                textBox.Location = new Point(10, 35);
                textBox.Size = new Size(480, 23);

                Button okButton = new Button();
                okButton.Text = "OK";
                okButton.Location = new Point(325, 70);
                okButton.DialogResult = DialogResult.OK;

                Button cancelButton = new Button();
                cancelButton.Text = "Отмена";
                cancelButton.Location = new Point(410, 70);
                cancelButton.DialogResult = DialogResult.Cancel;

                form.Controls.Add(label);
                form.Controls.Add(textBox);
                form.Controls.Add(okButton);
                form.Controls.Add(cancelButton);
                form.AcceptButton = okButton;
                form.CancelButton = cancelButton;

                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    return textBox.Text;
                }
                return null;
            }
        }

        // Кнопка меню "Случайные": заполняет таблицу 300 случайными числами
        private void случайныеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy) return;

            Random rnd = new Random();

            dataGridView1.Rows.Clear();

            for (int i = 0; i < 300; i++)
            {
                int number = rnd.Next(1, 1001); // числа от 1 до 1000
                int index = dataGridView1.Rows.Add();           // добавляем пустую строку
                dataGridView1.Rows[index].Cells[0].Value = number; // записываем число в ячейку
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isBusy)
            {
                // идёт анимация: просим её остановиться, очистка произойдёт в EndPlay
                stopRequested = true;
                return;
            }

            ClearAll();
        }

        // Очистка таблицы, подписей и графиков
        private void ClearAll()
        {

            dataGridView1.Rows.Clear();

            bubbleLabel.Text = "";
            insertionLabel.Text = "";
            shakerLabel.Text = "";
            quickLabel.Text = "";
            bogoLabel.Text = "";

            ClearPlots();

            // забываем старый расчёт - повторять больше нечего
            lastData = null;
            lastSorted = null;
            ranBubble = false;
            ranInsertion = false;
            ranShaker = false;
            ranQuick = false;
            ranBogo = false;
        }

        // Анимация

        // Очищает все графики
        private void ClearPlots()
        {
            bubblePlot.Plot.Clear();
            insertionPlot.Plot.Clear();
            shakerPlot.Plot.Clear();
            quickPlot.Plot.Clear();
            bogoPlot.Plot.Clear();

            bubblePlot.Refresh();
            insertionPlot.Refresh();
            shakerPlot.Refresh();
            quickPlot.Refresh();
            bogoPlot.Refresh();
        }

        // Для больших массивов анимацию не проигрываем
        private bool IsTooBigForAnimation()
        {
            if (lastData != null && lastData.Length > MaxAnimationSize)
            {
                MessageBox.Show("Элементов больше " + MaxAnimationSize + ", анимация не показывается.\n" +
                                "Отсортированный результат можно скачать в Excel (кнопка \"Скачать\" в меню).",
                                "Анимация отключена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }

        // Начало и конец анимации: блокируем кнопки, чтобы не запустить две анимации сразу
        private void StartPlay()
        {
            isBusy = true;
            SetReplayButtons(false);
        }

        private void EndPlay()
        {
            SetReplayButtons(true);
            isBusy = false;

            // если во время анимации нажали "Очистить" - очищаем теперь, когда анимация остановилась
            if (stopRequested)
            {
                stopRequested = false;
                ClearAll();
            }
        }

        private void SetReplayButtons(bool enabled)
        {
            bubbleReplayButton.Enabled = enabled;
            insertionReplayButton.Enabled = enabled;
            shakerReplayButton.Enabled = enabled;
            quickReplayButton.Enabled = enabled;
            bogoReplayButton.Enabled = enabled;
        }

        // Проигрывает анимацию всех рассчитанных алгоритмов (после кнопки "Рассчитать")
        private void PlayAnimation()
        {
            StartPlay();

            if (ranBubble && !stopRequested) AnimateBubble();
            if (ranInsertion && !stopRequested) AnimateInsertion();
            if (ranShaker && !stopRequested) AnimateShaker();
            if (ranQuick && !stopRequested) AnimateQuick();
            if (ranBogo && !stopRequested) AnimateBogo();

            EndPlay();
        }

        private void AnimateBubble()
        {
            tabControl1.SelectedIndex = 0; // открываем нужную вкладку
            stepCounter = 0;
            if (lastData.Length <= 50) drawEvery = 1; else drawEvery = 100;
            int[] b = CopyArray(lastData);
            DrawArray(bubblePlot, b); // начальное состояние
            Thread.Sleep(300);
            BubbleSort(b, lastAsc, bubblePlot);
            DrawArray(bubblePlot, b);
        }

        private void AnimateInsertion()
        {
            tabControl1.SelectedIndex = 1; // открываем нужную вкладку
            stepCounter = 0;
            if (lastData.Length <= 50) drawEvery = 1; else drawEvery = 3;
            int[] b = CopyArray(lastData);
            DrawArray(insertionPlot, b);
            Thread.Sleep(300);
            InsertionSort(b, lastAsc, insertionPlot);
            DrawArray(insertionPlot, b);
        }

        private void AnimateShaker()
        {
            tabControl1.SelectedIndex = 2; // открываем нужную вкладку
            stepCounter = 0;
            if (lastData.Length <= 50) drawEvery = 1; else drawEvery = 100;
            int[] b = CopyArray(lastData);
            DrawArray(shakerPlot, b);
            Thread.Sleep(300);
            ShakerSort(b, lastAsc, shakerPlot);
            DrawArray(shakerPlot, b);
        }

        private void AnimateQuick()
        {
            tabControl1.SelectedIndex = 3; // открываем нужную вкладку
            stepCounter = 0;
            if (lastData.Length <= 50) drawEvery = 1; else drawEvery = 8;
            int[] b = CopyArray(lastData);
            DrawArray(quickPlot, b);
            Thread.Sleep(300);
            QuickSort(b, 0, b.Length - 1, lastAsc, quickPlot);
            DrawArray(quickPlot, b);
        }

        private void AnimateBogo()
        {
            tabControl1.SelectedIndex = 4; // открываем нужную вкладку
            stepCounter = 0;
            if (lastData.Length <= 50) drawEvery = 1; else drawEvery = 1;
            // BOGO тасует случайно, поэтому при каждом повторе длина анимации разная
            int[] b = CopyArray(lastData);
            DrawArray(bogoPlot, b);
            Thread.Sleep(300);
            BogoSort(b, lastAsc, bogoPlot);
            DrawArray(bogoPlot, b);
        }

        // Вспомогательные методы

        // Копия массива (чтобы не портить исходные данные)
        private int[] CopyArray(int[] source)
        {
            int[] result = new int[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                result[i] = source[i];
            }
            return result;
        }

        // Превращает массив в строку для label
        private string ArrayToString(int[] a)
        {
            if (a.Length > 30)
            {
                return "(массив слишком большой для вывода)";
            }
            return string.Join(", ", a);
        }

        // Нужно ли ставить x раньше y?
        private bool Compare(int x, int y, bool asc)
        {
            if (asc)
            {
                return x < y;
            }
            else
            {
                return x > y;
            }
        }

        // Рисует массив столбцами на графике
        private void DrawArray(FormsPlot plot, int[] a)
        {
            // Если график ещё не создан или имеет нулевой размер (например, вкладка
            // ни разу не открывалась), рисовать нельзя - библиотека выдаёт ошибку
            if (a.Length == 0) return;
            if (!plot.IsHandleCreated) return;
            if (plot.Width < 10 || plot.Height < 10) return;

            double[] values = new double[a.Length];
            for (int i = 0; i < a.Length; i++)
            {
                values[i] = a[i];
            }

            plot.Plot.Clear();
            plot.Plot.Add.Bars(values);
            plot.Plot.Axes.AutoScale();
            plot.Refresh();
        }

        // Рисует шаг сортировки (только если график передан).
        // Для больших массивов рисуется не каждый шаг, а каждый drawEvery-й.
        private void DrawStep(FormsPlot plot, int[] a)
        {
            if (plot == null) return;

            stepCounter++;
            if (stepCounter % drawEvery != 0) return;

            DrawArray(plot, a);
            Application.DoEvents();
            Thread.Sleep(20);
        }

        // Алгоритмы сортировки

        // Пузырьковая
        // Много раз проходим по массиву и сравниваем соседние элементы между собой
        // если стоят не в том порядке - меняются местами
        private void BubbleSort(int[] a, bool asc, FormsPlot plot)
        {
            int n = a.Length;

            for (int i = 0; i < n - 1; i++) // проходим по массиву
            {
                for (int j = 0; j < n - 1 - i; j++) // проходим по парам
                {
                    iterations++;
                    if (stopRequested) return; // нажали "Очистить"
                    if (Compare(a[j + 1], a[j], asc)) // сравниваем пару
                    {
                        // меняем местами через временную переменную
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;

                        DrawStep(plot, a);
                    }
                }
            }
        }

        // Вставками
        // Первый элемент считается отсортированным, алгоритм берёт следующий элемент (ключ)
        // из неотсортированной части (справа) и сравнивает с отсортированными элементами (слева)
        // элементы, которые больше ключа сдвигаются на 1 позицию вправо, ключ вставляется
        // в освободившееся место
        private void InsertionSort(int[] a, bool asc, FormsPlot plot)
        {
            // i - граница: слева от i уже отсортировано
            for (int i = 1; i < a.Length; i++)
            {
                iterations++;
                if (stopRequested) return; // нажали "Очистить"
                int key = a[i]; // берём элемент, который будем вставлять
                int j = i - 1; // сравниваем с левым соседом

                while (j >= 0 && Compare(key, a[j], asc)) // пока ключ должен стоять левее j-ого соседа
                {
                    iterations++;
                    if (stopRequested) return; // нажали "Очистить"
                    a[j + 1] = a[j]; // сдвигаем вправо
                    j = j - 1; // идём дальше влево
                }

                a[j + 1] = key; // вставляем ключ в освободившееся место

                DrawStep(plot, a);
            }
        }

        // Шейкерная
        // Просматриваем массив в двух направлениях слева и справа
        // первый проход вправо перемещает самый большой элемент в конец
        // первый прохо влево перемещает самый маленький элемент в начало
        // последующие проходы уже без этих отсортированных элементов - неотсортированная
        // область сужается с каждым проходом 
        private void ShakerSort(int[] a, bool asc, FormsPlot plot)
        {
            int left = 0; // левая граница неотсортированной части
            int right = a.Length - 1; // правая граница неотсортированной части

            while (left < right) // проходим вправо
            {
                for (int i = left; i < right; i++)
                {
                    iterations++;
                    if (stopRequested) return; // нажали "Очистить"
                    // сравниваем и меняем местами соседей как в Пузырьковой
                    if (Compare(a[i + 1], a[i], asc))
                    {
                        int temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;

                        DrawStep(plot, a);
                    }
                }
                right--; // последний элемент встал на место, граница сдвигается

                // проходим влево
                for (int i = right; i > left; i--)
                {
                    iterations++;
                    if (stopRequested) return; // нажали "Очистить"
                    if (Compare(a[i], a[i - 1], asc))
                    {
                        int temp = a[i];
                        a[i] = a[i - 1];
                        a[i - 1] = temp;

                        DrawStep(plot, a);
                    }
                }
                left++;
            }
        }

        // Быстрая
        // Выбираем опорный элемент (pivot), переставляем массив так, чтобы слева от него
        // оказались все элементы, которые меньше него, а справа все остальные
        // pivot стоит на своем месте, слева и справа от него два подмассива
        // процесс повторяется для каждого из подмассивов пока их размер не станет 0 или 1
        // выполняется рекурсивно, т.е. вызывает сам себя
        private void QuickSort(int[] a, int low, int high, bool asc, FormsPlot plot)
        {
            if (low >= high) return; // отрезок из 0 или 1 элемента уже отсортирован

            int pivot = a[high]; // опорный элемент - последний в отрезке
            int i = low; // граница (меньше опорного элемента)

            for (int j = low; j < high; j++) // идём по отрезку
            {
                iterations++;
                if (stopRequested) return; // нажали "Очистить"
                if (Compare(a[j], pivot, asc)) // текущий элемент меньше pivot?
                {
                    // меняем местами элементы
                    int temp = a[i];
                    a[i] = a[j];
                    a[j] = temp;
                    i++;

                    DrawStep(plot, a);
                }
            }

            // ставим pivot на его место: между левой и правой частями
            int temp2 = a[i];
            a[i] = a[high];
            a[high] = temp2;

            DrawStep(plot, a);

            QuickSort(a, low, i - 1, asc, plot); // проходимся по левому подмассиву
            QuickSort(a, i + 1, high, asc, plot); // проходимся по правому подмассиву
        }

        // BOGO
        // переставляем рандомно массив пока он не отсортируется
        private bool BogoSort(int[] a, bool asc, FormsPlot plot)
        {
            Random rnd = new Random();
            int attempts = 0;
            int maxAttempts = 5000000; // ограничение на количество попыток отсортировать

            while (!IsSorted(a, asc)) // пока не отсортирован
            {
                if (stopRequested)
                {
                    return false; // нажали "Очистить"
                }

                if (attempts >= maxAttempts)
                {
                    return false; // не смогли за 5 млн раз отсортировать - сдаёмся
                }

                // перемешиваем элементы
                for (int i = 0; i < a.Length; i++)
                {
                    int k = rnd.Next(a.Length); // случайный индекс
                    int temp = a[i];
                    a[i] = a[k];
                    a[k] = temp;
                }

                attempts++;
                iterations++;

                if (attempts <= 50)
                {
                    // показываем только первые 50 перемешиваний
                    DrawStep(plot, a);
                }
                else if (plot != null && attempts % 10000 == 0)
                {
                    // дальше сортируем без рисования, но даём форме обновляться
                    Application.DoEvents();
                }
            }

            return true;
        }

        // Проверка: отсортирован ли массив
        private bool IsSorted(int[] a, bool asc)
        {
            for (int i = 1; i < a.Length; i++)
            {
                if (Compare(a[i], a[i - 1], asc))
                {
                    return false;
                }
            }
            return true;
        }
    }
}