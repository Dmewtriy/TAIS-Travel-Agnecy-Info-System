using AuthorizationLibrary;
using System.Data;
using TAIS__Tourist_Agency_Info_System_.Data.Repositories;
using TAIS__Tourist_Agency_Info_System_.Entities.Class;
using TAIS__Tourist_Agency_Info_System_.Entities.Enums;

namespace EmployeeModule
{
    public partial class EmployeeForm : Form
    {
        private InitRepos dataBase;
        private List<Employee> allEmployees;
        private List<Position> allPositions;
        private List<HREvent> allHrEvents;
        private List<Street> allStreets;
        private List<HREvent> hrEventsForSelectedEmployee;
        private List<Employee> filteredEmployees;
        private Employee selectedEmployee;
        private int userId;
        private MenuState menuState;

        public EmployeeForm(InitRepos init, int user_id, MenuState menuState)
        {
            InitializeComponent();
            dataBase = init;
            userId = user_id;
            this.menuState = menuState;

            // Важно: отключем автосоздание колонок до загрузки данных
            employeesDataGridView.AutoGenerateColumns = false;
            dataGridView1.AutoGenerateColumns = false;

            InitializeForm();
            LoadData();
        }

        private void InitializeForm()
        {
            // Настройка начальных значений
            eventDatePicker.Value = DateTime.Today;

            // Заполнение ComboBox для типа мероприятия
            eventTypeComboBox.Items.AddRange(new string[] { "Прием", "Перевод", "Увольнение" });
            eventTypeComboBox.SelectedIndex = 0; // Прием по умолчанию

            // Настройка событий
            employeesDataGridView.SelectionChanged += EmployeesDataGridView_SelectionChanged;
            dataGridView1.CellFormatting += EmploymentHistoryDataGridView_CellFormatting;

            applyFilterButton.Click += ApplyFilterButton_Click;
            resetFilterButton.Click += ResetFilterButton_Click;
            deleteEmployeeButton.Click += DeleteEmployeeButton_Click;
            selectEmployeeButton.Click += SelectEmployeeButton_Click;
            addEmployeeButton.Click += AddEmployeeButton_Click;
            editEmployeeButton.Click += EditEmployeeButton_Click;
            deleteEmploymentButton.Click += DeleteEmploymentButton_Click;
            addEmploymentButton.Click += AddEmploymentButton_Click;
            exitButton.Click += ExitButton_Click;

            // Двойной клик по сотруднику для выбора
            employeesDataGridView.CellDoubleClick += EmployeesDataGridView_CellDoubleClick;

            // Дополнительные события
            positionComboBox.SelectedIndexChanged += positionComboBox_SelectedIndexChanged;
            dataGridView1.SelectionChanged += employmentHistoryDataGridView_SelectionChanged;

            // Обработчик изменения типа мероприятия для контроля доступности поля причины увольнения
            eventTypeComboBox.SelectedIndexChanged += EventTypeComboBox_SelectedIndexChanged;

            // Обновление доступности кнопок
            UpdateButtonsState();
        }

        private void EventTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void LoadData()
        {
            // Загрузка всех сотрудников и должностей
            allEmployees = dataBase.employeeRep.GetAll();
            allPositions = dataBase.positionRep.GetAll();
            allHrEvents = dataBase.hrEventRep.GetAll();
            // Загрузка улиц (мест работы) для автозаполнения
            try { allStreets = dataBase.streetRep.GetAll(); } catch { allStreets = new List<Street>(); }

            // Заполнение фильтра должностей
            positionFilterComboBox.Items.Clear();
            positionFilterComboBox.Items.Add("Все должности");
            positionComboBox.Items.Clear();

            foreach (var position in allPositions)
            {
                positionFilterComboBox.Items.Add(position.Title);
                positionComboBox.Items.Add(position.Title);
            }

            foreach (var street in allStreets)
            {
                workplaceCombo.Items.Add(street.Name);
            }

            positionFilterComboBox.SelectedIndex = 0;
            if (positionComboBox.Items.Count > 0)
                positionComboBox.SelectedIndex = 0;

            // Инициализация фильтрованного списка
            filteredEmployees = allEmployees.ToList();

            // Настраиваем DataPropertyName для колонок
            SetupDataGridViewColumns();

            // Обновление списка сотрудников
            UpdateEmployeesDataGridView();
        }

        private void SetupDataGridViewColumns()
        {
            // Настройка колонок для таблицы сотрудников
            colSurname.DataPropertyName = "Surname";
            colName.DataPropertyName = "Name";
            colPatronymic.DataPropertyName = "Patronymic";
        }

        private void UpdateEmployeesDataGridView()
        {
            // Очищаем существующие строки
            employeesDataGridView.Rows.Clear();

            // Добавляем строки вручную
            int rowNumber = 1;
            foreach (var employee in filteredEmployees)
            {
                int rowIndex = employeesDataGridView.Rows.Add();
                DataGridViewRow row = employeesDataGridView.Rows[rowIndex];

                row.Cells["colEmployeeNumber"].Value = rowNumber;
                row.Cells["colSurname"].Value = employee.LastName;
                row.Cells["colName"].Value = employee.FirstName;
                row.Cells["colPatronymic"].Value = employee.MiddleName;
                row.Cells["colPosition"].Value = employee.Position?.Title ?? "Не указано";

                // Сохраняем объект Employee в Tag строки для доступа позже
                row.Tag = employee;

                rowNumber++;
            }
        }

        private void UpdateEmploymentHistoryData()
        {
            InitRepos initRepos = new InitRepos();
            allHrEvents = initRepos.hrEventRep.GetAll();
            // Очищаем существующие строки
            dataGridView1.Rows.Clear();

            // Загружаем все кадровые мероприятия для выбранного сотрудника по его Id
            hrEventsForSelectedEmployee = (selectedEmployee != null && allHrEvents != null)
                ? allHrEvents.Where(ev => ev.EmployeeId == selectedEmployee.Id).ToList()
                : new List<HREvent>();

            if (selectedEmployee != null && hrEventsForSelectedEmployee != null)
            {
                // Сортируем записи по дате документа (новые сверху)
                var sortedHistories = hrEventsForSelectedEmployee
                    .OrderByDescending(h => h.EventDate)
                    .ToList();

                foreach (var history in sortedHistories)
                {
                    int rowIndex = dataGridView1.Rows.Add();
                    DataGridViewRow row = dataGridView1.Rows[rowIndex];

                    row.Cells["date"].Value = history.EventDate.ToShortDateString();
                    row.Cells["position"].Value = history.Position?.Title ?? "Не указано";
                    row.Cells["workplace"].Value = history.WorkPlace?.Name ?? history.OrgName ?? string.Empty;
                    row.Cells["eventType"].Value = history.EventType.GetStringByEnum();
                    row.Cells["documentType"].Value = history.DocumentType ?? string.Empty;
                    row.Cells["reason"].Value = history.Reason ?? string.Empty;

                    // Сохраняем объект EmploymentHistory в Tag строки
                    row.Tag = history;
                }
            }
        }

        private void ClearEmploymentForm()
        {
            if (positionComboBox.Items.Count > 0)
                positionComboBox.SelectedIndex = 0;
            workplaceCombo.SelectedIndex = 0;
            eventDatePicker.Value = DateTime.Today;
            documentNumberTextBox.Clear();
            documentTypeTextBox.Clear();
            dismissalReasonTextBox.Clear();
            if (eventTypeComboBox.Items.Count > 0)
                eventTypeComboBox.SelectedIndex = 0;
        }

        private void UpdateButtonsState()
        {
            bool hasSelectedEmployee = selectedEmployee != null;
            bool hasSelectedHistory = dataGridView1.SelectedRows.Count > 0;
            bool hasSelectedRow = employeesDataGridView.SelectedRows.Count > 0;

            selectEmployeeButton.Enabled = hasSelectedRow;
            deleteEmployeeButton.Enabled = hasSelectedRow;
            editEmployeeButton.Enabled = hasSelectedRow;
            deleteEmploymentButton.Enabled = hasSelectedHistory;

            // Включение/выключение поля причины увольнения
            bool isDismissal = eventTypeComboBox.SelectedItem?.ToString() == "Увольнение";
            dismissalReasonLabel.Enabled = isDismissal;
            dismissalReasonTextBox.Enabled = isDismissal;
        }

        // Обработчики событий
        private void ApplyFilterButton_Click(object sender, EventArgs e)
        {
            string searchText = searchTextBox.Text.Trim();
            string selectedPosition = positionFilterComboBox.SelectedItem?.ToString();

            // Начинаем со всех сотрудников
            filteredEmployees = allEmployees.ToList();

            // Фильтрация по поисковому тексту (ФИО)
            if (!string.IsNullOrWhiteSpace(searchText))
            {
                filteredEmployees = filteredEmployees
                    .Where(emp => emp.GetFullName().ToLower().Contains(searchText.ToLower()) ||
                                 emp.LastName.ToLower().Contains(searchText.ToLower()) ||
                                 emp.FirstName.ToLower().Contains(searchText.ToLower()) ||
                                 (emp.MiddleName != null && emp.MiddleName.ToLower().Contains(searchText.ToLower())))
                    .ToList();
            }

            // Фильтрация по должности
            if (selectedPosition != "Все должности" && !string.IsNullOrEmpty(selectedPosition))
            {
                filteredEmployees = filteredEmployees
                    .Where(emp => emp.Position?.Title == selectedPosition)
                    .ToList();
            }

            if (filteredEmployees.Count == 0)
            {
                MessageBox.Show("Сотрудники по выбранным критериям не найдены", "Результат поиска",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            UpdateEmployeesDataGridView();
            UpdateButtonsState();
        }

        private void ResetFilterButton_Click(object sender, EventArgs e)
        {
            searchTextBox.Clear();
            positionFilterComboBox.SelectedIndex = 0;
            filteredEmployees = allEmployees.ToList();
            UpdateEmployeesDataGridView();
            UpdateButtonsState();
        }

        private void EmployeesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void SelectEmployeeButton_Click(object sender, EventArgs e)
        {
            if (employeesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = employeesDataGridView.SelectedRows[0];
                if (selectedRow.Tag is Employee employee)
                {
                    selectedEmployee = employee;
                    UpdateEmploymentHistoryData();
                    ClearEmploymentForm();
                    UpdateButtonsState();

                    MessageBox.Show($"Выбран сотрудник: {employee.GetFullName()}", "Выбор сотрудника",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EmployeesDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectEmployeeButton_Click(sender, e);
            }
        }

        private void DeleteEmployeeButton_Click(object sender, EventArgs e)
        {
            if (employeesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = employeesDataGridView.SelectedRows[0];
                if (selectedRow.Tag is Employee employee)
                {
                    var result = MessageBox.Show($"Вы уверены, что хотите удалить сотрудника {employee.GetFullName()}?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dataBase.employeeRep.Delete(employee.Id);
                            allEmployees = dataBase.employeeRep.GetAll();
                            filteredEmployees = allEmployees.ToList();
                            UpdateEmployeesDataGridView();

                            if (selectedEmployee == employee)
                            {
                                selectedEmployee = null;
                                UpdateEmploymentHistoryData();
                                ClearEmploymentForm();
                            }

                            UpdateButtonsState();

                            MessageBox.Show("Сотрудник успешно удален", "Удаление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении сотрудника: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void AddEmployeeButton_Click(object sender, EventArgs e)
        {
            // Открытие формы создания сотрудника
            using (var form = new EmployeeEditForm(allPositions))
            {
                if (form.ShowDialog() == DialogResult.OK && form.ResultEmployee != null)
                {
                    try
                    {
                        // Сохраняем нового сотрудника
                        dataBase.employeeRep.Save(form.ResultEmployee);

                        // Обновляем данные
                        allEmployees = dataBase.employeeRep.GetAll();
                        filteredEmployees = allEmployees.ToList();
                        UpdateEmployeesDataGridView();

                        MessageBox.Show("Сотрудник успешно добавлен", "Успех",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка при добавлении сотрудника: {ex.Message}", "Ошибка",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EditEmployeeButton_Click(object sender, EventArgs e)
        {
            if (employeesDataGridView.SelectedRows.Count > 0)
            {
                var selectedRow = employeesDataGridView.SelectedRows[0];
                if (selectedRow.Tag is Employee employee)
                {
                    // Открытие формы редактирования сотрудника
                    using (var form = new EmployeeEditForm(allPositions, employee))
                    {
                        if (form.ShowDialog() == DialogResult.OK && form.ResultEmployee != null)
                        {
                            try
                            {
                                // Обновляем данные сотрудника
                                dataBase.employeeRep.Save(form.ResultEmployee);

                                // Обновляем локальные данные
                                allEmployees = dataBase.employeeRep.GetAll();
                                filteredEmployees = allEmployees.ToList();
                                UpdateEmployeesDataGridView();

                                // Если редактируем выбранного сотрудника, обновляем его
                                if (selectedEmployee == employee)
                                {
                                    selectedEmployee = form.ResultEmployee;
                                    UpdateEmploymentHistoryData();
                                }

                                MessageBox.Show("Данные сотрудника успешно обновлены", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка при обновлении данных сотрудника: {ex.Message}", "Ошибка",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
        }

        private void AddEmploymentButton_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Сначала выберите сотрудника", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Получение выбранной должности
                string selectedPositionName = positionComboBox.SelectedItem?.ToString();
                Position selectedPost = allPositions.FirstOrDefault(p => p.Title == selectedPositionName);

                // Получение выбранной улицы
                string selectedWorkplace = workplaceCombo.SelectedItem?.ToString();
                Street selectedStreet = allStreets.FirstOrDefault(p => p.Name == selectedWorkplace);

                if (selectedPost == null)
                {
                    MessageBox.Show("Выберите должность", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Получение выбранного типа мероприятия
                string selectedEventType = eventTypeComboBox.SelectedItem?.ToString();
                if (string.IsNullOrEmpty(selectedEventType))
                {
                    MessageBox.Show("Выберите вид мероприятия", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Конвертация строки в enum TypeEvent
                TypeEvent typeEvent = TypeEventExtensions.GetEnumByString(selectedEventType);

                if (string.IsNullOrWhiteSpace(documentNumberTextBox.Text))
                {
                    MessageBox.Show("Введите номер документа", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    documentNumberTextBox.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(documentTypeTextBox.Text))
                {
                    MessageBox.Show("Введите вид документа", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    documentTypeTextBox.Focus();
                    return;
                }

                // Проверка причины увольнения для типа мероприятия "Увольнение"
                if (typeEvent == TypeEvent.Dismissal && string.IsNullOrWhiteSpace(dismissalReasonTextBox.Text))
                {
                    MessageBox.Show("Для увольнения необходимо указать причину", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dismissalReasonTextBox.Focus();
                    return;
                }

                InitRepos initRepos = new InitRepos();

                // Создание новой записи в трудовой книжке
                var employmentHistory = new HREvent(
                    0,
                    eventDatePicker.Value,
                    selectedStreet.Id,
                    typeEvent,
                    selectedPost.Title,
                    selectedPost.Title,
                    documentTypeTextBox.Text,
                    dismissalReasonTextBox.Text,
                    selectedPost.Id,
                    selectedEmployee.Id,
                    selectedStreet.Name
                );

                employmentHistory.WorkPlace = selectedStreet;
                employmentHistory.Position = selectedPost;
                employmentHistory.Employee = selectedEmployee;


                // Сохранение изменений в базе данных
                dataBase.employeeRep.Save(selectedEmployee);
                dataBase.hrEventRep.Save(employmentHistory);

                // Обновление отображения
                UpdateEmploymentHistoryData();
                ClearEmploymentForm();

                MessageBox.Show("Запись в трудовой книжке успешно добавлена", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show($"Ошибка валидации: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении записи: {ex.Message}", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteEmploymentButton_Click(object sender, EventArgs e)
        {
            if (selectedEmployee == null)
            {
                MessageBox.Show("Сначала выберите сотрудника", "Предупреждение",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dataGridView1.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridView1.SelectedRows[0];
                if (selectedRow.Tag is HREvent history)
                {
                    var result = MessageBox.Show("Вы уверены, что хотите удалить эту запись из трудовой книжки?",
                        "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            dataBase.hrEventRep.Delete(history.Id);
                            // Сохранение изменений в базе данных
                            dataBase.employeeRep.Save(selectedEmployee);

                            UpdateEmploymentHistoryData();
                            UpdateButtonsState();

                            MessageBox.Show("Запись успешно удалена", "Удаление",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Ошибка при удалении записи: {ex.Message}", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Форматирование ячеек таблиц
        private void EmploymentHistoryDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                if (row.Tag is HREvent history)
                {
                    switch (dataGridView1.Columns[e.ColumnIndex].Name)
                    {
                        case "date":
                            e.Value = history.EventDate.ToShortDateString();
                            break;
                        case "position":
                            e.Value = history.Position?.Title ?? "Не указано";
                            break;
                        case "workplace":
                            e.Value = history.WorkPlace.Name;
                            break;
                        case "eventType":
                            e.Value = history.EventType.GetStringByEnum();
                            break;
                        case "documentType":
                            e.Value = history.DocumentType;
                            break;
                        case "reason":
                            e.Value = history.Reason ?? "";
                            break;
                    }
                }
            }
        }

        private void positionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }

        private void employmentHistoryDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            UpdateButtonsState();
        }
    }
}