fetch(`/FilteredProducts`, {
    method: 'PUT'
})
    .then(response => response.json())
    .then(data => {
        const products = data;
        const uniqueTypes = [...new Set(data.map(product => product.type.name))];
        displayProducts(products, uniqueTypes);
    });


CreateMain();

document.addEventListener('DOMContentLoaded', function () {
    var panels = document.getElementById('search-filter-panel');

    var searchBox = panels.querySelector('#search-box');
    var cheapCheckbox = panels.querySelector('#cheap');
    var expensiveCheckbox = panels.querySelector('#expensive');
    var inputMin = panels.querySelector('#input-min');
    var inputMax = panels.querySelector('#input-max');


    searchBox.addEventListener('input', function (event) {
        PostDataFilters();
    });

    var timeoutId;
    var observer = new MutationObserver(function () {
        clearTimeout(timeoutId);
        timeoutId = setTimeout(function () {
            PostDataFilters();
        }, 500);
    });

    var config = { attributes: true, childList: true, subtree: true };
    observer.observe(panels, config);

    function PostDataFilters() {
        const formData = new FormData();

        formData.append('cheap', cheapCheckbox.checked);
        formData.append('expensive', expensiveCheckbox.checked);
        formData.append('min', inputMin.value);
        formData.append('max', inputMax.value);
        formData.append('search', searchBox.value);

        fetch(`/FilteredProducts`, {
            method: 'PUT',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                const products = data;
                const uniqueTypes = [...new Set(data.map(product => product.type.name))];
                displayProducts(products, uniqueTypes);
            });
    }
});





function CreateMain() {
    const mainPage = document.querySelector('div.page');

    const mainPanel = document.querySelector('.panel[data-type="main"]');

    if (mainPanel !== null) {
        mainPanel.remove();
    }

    const mainPanels = document.createElement('main');
    mainPanels.className = 'panel';
    mainPanels.setAttribute('data-type', 'main');

    mainPage.appendChild(mainPanels);
}

function displayProducts(products, uniqueTypes) {
    const mainPanel = document.querySelector('.panel[data-type="main"]');
    if (!mainPanel) return;

    mainPanel.innerHTML = '';

    uniqueTypes.forEach(type => {
        const section = document.createElement('section');
        section.className = 'group-panel';
        section.id = type.toLowerCase();

        const title = document.createElement('h2');
        title.className = 'panel-title';
        title.textContent = type;
        section.appendChild(title);

        productsByType(products, type).forEach(product => {
            const article = document.createElement('article');
            article.className = 'group-item';
            article.setAttribute('name', product.id);

            article.addEventListener('click', () => {
                const formData = new FormData();

                var id = article.getAttribute('name');

                formData.append('id', id);

                fetch(`/AddProductToBasket`, {
                    method: 'POST',
                    body: formData
                });
            });

            const main = document.createElement('main');
            main.className = 'item';
            main.setAttribute('data-type', 'main');

            const picture = document.createElement('picture');
            picture.className = 'item-picture';
            picture.setAttribute('data-type', 'main');

            const img = document.createElement('img');
            img.src = 'data:image.jpg;base64,' + product.photography;
            img.alt = '';
            picture.appendChild(img);
            main.appendChild(picture);

            const itemTitle = document.createElement('div');
            itemTitle.className = 'item-title';
            const itemName = document.createElement('a');
            itemName.href = '';
            itemName.className = 'item-name';
            itemName.textContent = product.name;
            itemTitle.appendChild(itemName);
            main.appendChild(itemTitle);

            const description = document.createElement('span');
            description.textContent = product.description;
            main.appendChild(description);

            const footer = document.createElement('footer');
            footer.className = 'item-footer';

            const itemPrice = document.createElement('div');
            itemPrice.className = 'item-price';
            itemPrice.textContent = product.price + ' руб.';
            footer.appendChild(itemPrice);

            const buyButton = document.createElement('button');
            buyButton.className = 'buy-item';
            buyButton.type = 'button';
            buyButton.setAttribute('data-type', 'select');
            buyButton.setAttribute('data-size', 'medium');
            buyButton.textContent = 'Выбрать';
            footer.appendChild(buyButton);

            article.appendChild(main);
            article.appendChild(footer);

            section.appendChild(article);
        });

        mainPanel.appendChild(section);
    });
}

function productsByType(products, type) {
    return products.filter(product => product.type.name === type);
}