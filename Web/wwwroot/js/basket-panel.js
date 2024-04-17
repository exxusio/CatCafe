document.addEventListener('DOMContentLoaded', function() {
    const basketButton = document.querySelector('.button[data-types="nav"]');
    const basketPanel = document.querySelector('.basket-window');

    basketButton.addEventListener('click', function() {
        const basketContainer = document.createElement('div');

        basketContainer.innerHTML = `
        <div class="background" style="opacity: 0;"></div>
                <div class="basket-panel" style="transform: translateX(500px);">
                    <button class="close" data-type="basket">
                        <svg width="25" height="25" viewBox="0 0 25 25" fill="none">
                            <path fill-rule="evenodd" clip-rule="evenodd" fill="#fff" d="M9.61 12.199L.54 3.129A1.833 1.833 0 113.13.536l9.07 9.07L21.27.54a1.833 1.833 0 012.592 2.592l-9.068 9.068 9.07 9.07a1.833 1.833 0 01-2.59 2.592l-9.072-9.07-9.073 9.073a1.833 1.833 0 01-2.591-2.592L9.61 12.2z"></path>
                        </svg>
                    </button>
                    <div class="basket-frame" data-mibile="false">
                        <div style="position: relative; overflow: hidden; width: 100%; height: 100%;">
                            <div class="basket-scroll">
                                <main class="basket-list">
                                    <section class="basket-header">
                                        <h1 class="basket-title">N6 товаров N руб.</h1>
                                    </section>
                                    
                                    <section id="basket-section">
                                    
                                    </section>

                                    <div class="basket-footer">
                                        <div class="basket-foot fixed">
                                            <div class="basket-price">N руб.</div>
                                            <button class="button" type="button" data-type="primary" data-size="medium" data-types="basket-order">
                                                Заказать
                                                <svg width="24" height="24" viewBox="0 0 24 24" fill="none" class="basket-arrow">
                                                    <path d="M10 18l6-6-6-6" stoke="#000" stroke-width="2"></path>
                                                </svg>
                                            </button>
                                        </div>
                                    </div>
                                </main>
                            </div>
                        </div>
                    </div>
                </div>
        `;

        basketPanel.appendChild(basketContainer);

        setTimeout(() => {
            const basketPanel = basketContainer.querySelector('.basket-panel');
            background.style.transition = 'opacity 300ms ease-out';
            basketPanel.style.transition = 'transform 300ms ease-out';
            background.style.opacity = '1';
            basketPanel.style.transform = 'translateX(0px)';
        }, 100);

        document.body.style.overflow = 'hidden';
        document.body.style.overscrollBehavior = 'contain';
        document.body.style.position = 'relative';
        document.body.style.paddingRight = '15px';
        
        const basketCloseButton = basketContainer.querySelector('.close[data-type="basket"]');
        basketCloseButton.addEventListener('click', closeBasket);
        const background = basketContainer.querySelector('.background');
        background.addEventListener('click', closeBasket);

        function closeBasket() {
            const background = basketContainer.querySelector('.background');
            const basketPanel = basketContainer.querySelector('.basket-panel');
            background.style.opacity = '0';
            basketPanel.style.transform = 'translateX(100%)';
        
            setTimeout(() => {
                basketContainer.remove();

                document.body.style.overflow = '';
                document.body.style.overscrollBehavior = '';
                document.body.style.position = '';
                document.body.style.paddingRight = '';
            }, 300);
        }

        const basketConfirmOrder = document.querySelector('.button[data-types="basket-order"]');

        basketConfirmOrder.addEventListener('click', () => {

            fetch(`/ConfirmOrder`, {
                method: 'POST'
            })
                .then(response => {
                    if (response.ok) {
                        return response.text().then(message => {
                            ViewNotify('Успех', message);
                        });
                    }
                    else
                        return response.text().then(errorMessage => {
                            throw errorMessage;
                        });
                })
                .catch(error => {
                    ViewNotify('Ошибка', error);
                });

            const basketList = document.getElementById('basket-section');
            basketList.innerHTML = ``;

            const basketPrice = document.querySelector('.basket-price');
            basketPrice.textContent = "0 руб.";
            const basketTitle = document.querySelector('.basket-title');
            basketTitle.textContent = "0 товаров на 0 руб.";
        });

        CreateBasketList();
    });
});

function CreateBasketList() {
    const basketList = document.getElementById('basket-section');
    basketList.innerHTML = ``;

    var summ = 0;
    var count = 0;

    fetch(`/ViewBasket`, {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => {

            data.forEach(product => {
                const article = document.createElement('article');
                article.classList.add('basket-item');

                const itemDeleteBtn = document.createElement('button');
                itemDeleteBtn.classList.add('item-delete');
                itemDeleteBtn.setAttribute('name', product.key.id);
                itemDeleteBtn.innerHTML = `
                    <svg fill="none" viewBox="0 0 24 24">
                        <path fill="#000" d="M17.3 5.3a1 1 0 111.4 1.4L13.42 12l5.3 5.3a1 1 0 11-1.42 1.4L12 13.42l-5.3 5.3a1 1 0 01-1.4-1.42l5.28-5.3-5.3-5.3A1 1 0 016.7 5.3l5.3 5.28 5.3-5.3z"></path>
                    </svg>
                `;

                const itemDiv = document.createElement('div');
                itemDiv.classList.add('item');
                itemDiv.setAttribute('data-type', 'basket');
                itemDiv.innerHTML = `
                    <picture class="item-picture" data-type="basket">
                        <img src="data:image.jpg;base64,${product.key.photography}" alt="">
                    </picture>
                    <div class="item-info" data-type="basket">
                        <h3 class="item-title" data-type="basket">${product.key.name}</h3>
                        <section class="item-discription" data-type="basket">${product.key.description}</section>
                    </div>
                `;

                const itemFooter = document.createElement('div');
                itemFooter.classList.add('item-footer');
                itemFooter.setAttribute('data-type', 'basket');
                itemFooter.innerHTML = `
                     <div class="item-price" data-type="basket">
                         <div class="price" data-type="basket">${product.key.price} руб.</div>
                     </div>
                     <div class="item-count" data-type="basket">
                         <div class="counts" data-type="basket">

                         </div>
                     </div>
                 `;


                const countsBasket = itemFooter.querySelector('.counts[data-type="basket"]');

                const plusProduct = document.createElement('button');
                plusProduct.classList.add('count');
                plusProduct.setAttribute('data-type', '+-');
                plusProduct.setAttribute('type', 'button');
                plusProduct.setAttribute('name', product.key.id);
                plusProduct.innerHTML = `
                     <svg width="10" height="10" viewBox="0 0 10 10">
                         <g>
                             <rect x="4" width="2" height="10" ry="1"></rect>
                             <rect y="4" width="10" height="2" rx="1"></rect>
                         </g>
                     </svg>
                `;

                const countProduct = document.createElement('div');
                countProduct.classList.add('count');
                countProduct.setAttribute('data-type', 'count');
                countProduct.setAttribute('name', product.key.id);
                countProduct.textContent = product.value;

                const minusProduct = document.createElement('button');
                minusProduct.classList.add('count');
                minusProduct.setAttribute('data-type', '+-');
                minusProduct.setAttribute('type', 'button');
                minusProduct.setAttribute('name', product.key.id);
                minusProduct.innerHTML = `
                     <svg width="10" height="10" viewBox="0 0 10 10">
                         <rect y="4" width="10" height="2" rx="1"></rect>
                     </svg>
                `;

                itemDeleteBtn.addEventListener('click', () => {

                    const formData = new FormData();

                    var id = itemDeleteBtn.getAttribute('name');

                    formData.append('id', id);

                    fetch(`/RemoveFromBasket`, {
                        method: 'PUT',
                        body: formData
                    })
                        .then(response => {
                            if (response.ok) {
                                const price = parseInt(product.key.price);

                                const basketPrice = document.querySelector('.basket-price');
                                summ -= (price * parseInt(countProduct.innerHTML));
                                basketPrice.textContent = summ + " руб.";
                                const basketTitle = document.querySelector('.basket-title');
                                count -= parseInt(countProduct.innerHTML);
                                basketTitle.textContent = count + " товаров на " + summ + " руб.";


                                article.remove();
                            }
                            else
                                return response.text().then(errorMessage => {
                                    throw errorMessage;
                                });
                        })
                        .catch(error => {
                            ViewNotify('Ошибка', error);
                        });
                });

                plusProduct.addEventListener('click', () => {

                    const formData = new FormData();

                    var id = plusProduct.getAttribute('name');

                    formData.append('id', id);
                    formData.append('action', 1);

                    fetch(`/AddToBasket`, {
                        method: 'PUT',
                        body: formData
                    })
                        .then(response => {
                            if (response.ok) {
                                countProduct.innerHTML = parseInt(countProduct.innerHTML) + 1;

                                const price = parseInt(product.key.price);

                                const basketPrice = document.querySelector('.basket-price');
                                summ += price;
                                basketPrice.textContent = summ + " руб.";
                                const basketTitle = document.querySelector('.basket-title');
                                count++;
                                basketTitle.textContent = count + " товаров на " + summ + " руб.";
                            }
                            else
                                return response.text().then(errorMessage => {
                                    throw errorMessage;
                                });
                        })
                        .catch(error => {
                            ViewNotify('Ошибка', error);
                        });
                });

                minusProduct.addEventListener('click', () => {

                    const formData = new FormData();

                    var id = plusProduct.getAttribute('name');

                    formData.append('id', id);
                    formData.append('action', parseInt('-1'));

                    fetch(`/AddToBasket`, {
                        method: 'PUT',
                        body: formData
                    })
                        .then(response => {
                            if (response.ok) {
                                countProduct.innerHTML = parseInt(countProduct.innerHTML) - 1;

                                const price = parseInt(product.key.price);

                                const basketPrice = document.querySelector('.basket-price');
                                summ -= price;
                                basketPrice.textContent = summ + " руб.";
                                const basketTitle = document.querySelector('.basket-title');
                                count--;
                                basketTitle.textContent = count + " товаров на " + summ + " руб.";

                                if (parseInt(countProduct.innerHTML) <= 0)
                                    article.remove();
                            }
                            else
                                return response.text().then(errorMessage => {
                                    throw errorMessage;
                                });
                        })
                        .catch(error => {
                            ViewNotify('Ошибка', error);
                        });

                });

                summ += product.key.price * product.value;
                count += product.value;

                article.appendChild(itemDeleteBtn);
                article.appendChild(itemDiv);
                countsBasket.appendChild(minusProduct);
                countsBasket.appendChild(countProduct);
                countsBasket.appendChild(plusProduct);
                article.appendChild(itemFooter);
                basketList.appendChild(article);
            });

            const basketPrice = document.querySelector('.basket-price');
            basketPrice.textContent = summ + " руб.";
            const basketTitle = document.querySelector('.basket-title');
            basketTitle.textContent = count + " товаров на " + summ + " руб.";
        });
}