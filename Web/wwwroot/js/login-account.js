const executeAction = localStorage.getItem('executeAction');
if (executeAction === 'true') {
    setTimeout(() => {
        ViewNotify('Успех', 'Вы успешно зарегистрировались!');
        localStorage.removeItem('executeAction');
    }, 500);
}

var loginButton = document.getElementById('login');

loginButton.addEventListener('click', (event) => {

    const loginInput = document.querySelector('input[type="login"]');
    const passInput = document.querySelector('input[type="pass"]');


    if ((loginInput !== null && loginInput !== undefined)
        && (passInput !== null && passInput !== undefined)) {

        if (loginInput.value !== ''
            && passInput.value !== '') {



            const formData = new FormData();

            formData.append('login', loginInput.value);
            formData.append('password', passInput.value);



            fetch(`/LoginAccount`, {
                method: 'POST',
                body: formData
            })
                .then(response => {
                    if (response.redirected) {
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
