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
                                        <h1 class="basket-title">6 товаров бла бла бла</h1>
                                    </section>
                                    
                                    <section>
                                        <article class="basket-item">
                                            <button class="item-delete">
                                                <svg fill="none" viewBox="0 0 24 24">
                                                    <path fill="#000" d="M17.3 5.3a1 1 0 111.4 1.4L13.42 12l5.3 5.3a1 1 0 11-1.42 1.4L12 13.42l-5.3 5.3a1 1 0 01-1.4-1.42l5.28-5.3-5.3-5.3A1 1 0 016.7 5.3l5.3 5.28 5.3-5.3z"></path>
                                                </svg>
                                            </button>
                                            <div class="item" data-type="basket" >
                                                <picture class="item-picture" data-type="basket">
                                                    <img src="./content/image/pepperoni.png" alt="">
                                                </picture>
                                                <div class="item-info" data-type="basket">
                                                    <h3 class="item-title" data-type="basket">Пепперони</h3>
                                                    <section class="item-discription" data-type="basket">Пикантная пепперони, мно-о-ого моцареллы и томатный соус. Самая популярная пицца
                                                        <div></div>
                                                        <div></div>
                                                    </section>
                                                </div>
                                            </div>
                                            <div class="item-footer" data-type="basket">
                                                <div class="item-price" data-type="basket">
                                                    <div class="price" data-type="basket">13,99 руб.</div>
                                                </div>
                                                <div class="item-count" data-type="basket">
                                                    <div class="counts" data-type="basket">
                                                        <button class="count" data-type="+-" type="button">
                                                            <svg width="10" height="10" viewBox="0 0 10 10">
                                                                <rect y="4" width="10" height="2" rx="1"></rect>
                                                            </svg>
                                                        </button>
                                                        <div class="count" data-type="count">1</div>
                                                        <button class="count" data-type="+-" type="button">
                                                            <svg width="10" height="10" viewBox="0 0 10 10">
                                                                <g>
                                                                    <rect x="4" width="2" height="10" ry="1"></rect>
                                                                    <rect y="4" width="10" height="2" rx="1"></rect>
                                                                </g>
                                                            </svg>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                        </article>
                                    </section>

                                    <div class="basket-footer">
                                        <div class="basket-foot fixed">
                                            <div class="basket-price">бла бла</div>
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
    });
});


