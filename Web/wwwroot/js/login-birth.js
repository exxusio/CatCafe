var birthContainer = document.getElementById('birth-date');

if (birthContainer) {
    var daySelect = document.createElement('select');
    daySelect.className = 'input day';
    daySelect.setAttribute('data-type', 'birth');
    daySelect.required = true;
    var dayDefaultOption = document.createElement('option');
    dayDefaultOption.value = '';
    dayDefaultOption.textContent = 'День';
    dayDefaultOption.disabled = true;
    dayDefaultOption.selected = true;
    daySelect.appendChild(dayDefaultOption);
    for (var i = 1; i <= 31; i++) {
        var option = document.createElement('option');
        option.value = i;
        option.textContent = i;
        daySelect.appendChild(option);
    }
    birthContainer.appendChild(daySelect);
    
    var monthSelect = document.createElement('select');
    monthSelect.className = 'input month';
    monthSelect.setAttribute('data-type', 'birth');
    monthSelect.required = true;
    var monthDefaultOption = document.createElement('option');
    monthDefaultOption.value = '';
    monthDefaultOption.textContent = 'Месяц';
    monthDefaultOption.disabled = true;
    monthDefaultOption.selected = true;
    monthSelect.appendChild(monthDefaultOption);
    var months = ['Январь', 'Февраль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль', 'Август', 'Сентябрь', 'Октябрь', 'Ноябрь', 'Декабрь'];
    months.forEach(function(month, index) {
        var option = document.createElement('option');
        option.value = index + 1;
        option.textContent = month;
        monthSelect.appendChild(option);
    });
    birthContainer.appendChild(monthSelect);
    
    var yearSelect = document.createElement('select');
    yearSelect.className = 'input year';
    yearSelect.setAttribute('data-type', 'birth');
    yearSelect.required = true;
    var yearDefaultOption = document.createElement('option');
    yearDefaultOption.value = '';
    yearDefaultOption.textContent = 'Год';
    yearDefaultOption.disabled = true;
    yearDefaultOption.selected = true;
    yearSelect.appendChild(yearDefaultOption);
    var currentYear = new Date().getFullYear();
    for (var year = currentYear; year >= 1900; year--) {
        var option = document.createElement('option');
        option.value = year;
        option.textContent = year;
        yearSelect.appendChild(option);
    }
    birthContainer.appendChild(yearSelect);
}