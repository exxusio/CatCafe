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





var registerButton = document.getElementById('register');

registerButton.addEventListener('click', (event) => {

    const loginInput = document.querySelector('input[type="login"]');
    const emailInput = document.querySelector('input[type="email"]');
    const nameInput = document.querySelector('input[name="name"]');
    const surnameInput = document.querySelector('input[name="surname"]');
    const telInput = document.querySelector('input[type="tel"]');
    const passInput = document.querySelector('input[type="pass"]');

    const dayInput = document.querySelector('.input.day');
    const monthInput = document.querySelector('.input.month');
    const yearInput = document.querySelector('.input.year');

    
    if ((loginInput !== null && loginInput !== undefined)
        && (emailInput !== null && emailInput !== undefined)
        && (nameInput !== null && nameInput !== undefined)
        && (surnameInput !== null && surnameInput !== undefined)
        && (telInput !== null && telInput !== undefined)
        && (passInput !== null && passInput !== undefined)
        && (monthInput !== null && monthInput !== undefined)
        && (yearInput !== null && yearInput !== undefined)
        && (dayInput !== null && dayInput !== undefined)) {

        if (loginInput.value !== ''
            && emailInput.value !== ''
            && nameInput.value !== ''
            && surnameInput.value !== ''
            && telInput.value !== ''
            && passInput.value !== ''
            && monthInput.value !== ''
            && yearInput.value !== ''
            && dayInput.value !== '') {



            const formData = new FormData();

            formData.append('login', loginInput.value);
            formData.append('email', emailInput.value);
            formData.append('name', nameInput.value);
            formData.append('surname', surnameInput.value);
            formData.append('phoneNumber', telInput.value);
            formData.append('day', dayInput.value);
            formData.append('month', monthInput.value);
            formData.append('year', yearInput.value);
            formData.append('password', passInput.value);


            fetch(`/RegisterAccount`, {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (response.redirected) {
                        localStorage.setItem('executeAction', 'true');
                        window.location.href = response.url;
                    }
                    else
                        return response.text().then(errorMessage => {
                            throw errorMessage;
                        });
                })
                .catch(error => {
                    ViewNotify('Ошибка', error);
                });
        }
        else
            ViewNotify('Ошибка', 'Не все обязательные поля заполнены');
    }
    else
        ViewNotify('Ошибка', 'Поля ввода не обнаружены ;(');
});