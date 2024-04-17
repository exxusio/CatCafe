document.addEventListener('DOMContentLoaded', function() {
    const popularPanel = document.querySelector('.popular-panel');

    const prevButton = popularPanel.querySelector('.item.prev');
    const nextButton = popularPanel.querySelector('.item.next');
    const popularList = popularPanel.querySelector('.popular-list');
    const popularItems = popularPanel.querySelectorAll('.popular-item');
    const prevIcon = popularPanel.querySelector('.popular-button.prev');
    const nextIcon = popularPanel.querySelector('.popular-button.next');



    popularItems.forEach(item => {
        item.addEventListener('click', () => {
            const formData = new FormData();

            var id = item.getAttribute('name');

            formData.append('id', id);
            formData.append('action', 1);

            fetch(`/AddToBasket`, {
                method: 'PUT',
                body: formData
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
        });
    });



    let countMax = Math.ceil(parseFloat(getComputedStyle(popularList).width) / 260) - 1;
    let currentIndex = 0;
    let initialTransform = 0;

    if (popularItems.length > 0 && popularItems[0] !== null && popularItems[0] !== undefined) {
        const firstPopularItem = popularItems[0];
        firstPopularItem.classList.add('selected');


        window.addEventListener('resize', function () {
            countMax = Math.ceil(parseFloat(getComputedStyle(popularList).width) / 260) - 1;

            if (!(currentIndex < popularItems.length - countMax)) {
                currentIndex = popularItems.length - countMax;
                popularList.style.transform = `translate3d(-${currentIndex * 284}px, 0px, 0px)`;
            }
            if (currentIndex >= 0)
                markSelected(currentIndex);
        });


        function markSelected(index) {
            popularItems.forEach(item => item.classList.remove('selected'));
            popularItems[index].classList.add('selected');
        }

        function next() {
            if (currentIndex > 0 && currentIndex < popularItems.length - countMax) {
                currentIndex++;
                popularList.style.transform = `translate3d(-${currentIndex * 284}px, 0px, 0px)`;
                if (!(currentIndex < popularItems.length - countMax)) {
                    nextIcon.classList.remove('visible');
                }
                markSelected(currentIndex);
            }
        }

        function prev() {
            if (currentIndex > 0) {
                currentIndex--;
                popularList.style.transform = `translate3d(-${currentIndex * 284}px, 0px, 0px)`;
                if (!(currentIndex > 0)) {
                    prevIcon.classList.remove('visible');
                }
                markSelected(currentIndex);
            }
        }

        prevButton.addEventListener('click', prev);
        nextButton.addEventListener('click', next);

        prevButton.addEventListener('mouseenter', function () {
            if (currentIndex > 0) {
                prevIcon.classList.add('visible');
                initialTransform = parseInt(getComputedStyle(popularList).transform.split(',')[4]);
                popularList.style.transform = `translate3d(${initialTransform + 26}px, 0px, 0px)`;
                popularList.style.transitionDuration = '400ms';
            }
        });

        nextButton.addEventListener('mouseenter', function () {
            if (currentIndex < popularItems.length - countMax) {
                nextIcon.classList.add('visible');
                initialTransform = parseInt(getComputedStyle(popularList).transform.split(',')[4]);
                popularList.style.transform = `translate3d(${initialTransform - 26}px, 0px, 0px)`;
                popularList.style.transitionDuration = '400ms';
            }
        });

        prevButton.addEventListener('mouseleave', function () {
            prevIcon.classList.remove('visible');
            popularList.style.transform = `translate3d(-${currentIndex * 284}px, 0px, 0px)`;
            popularList.style.transitionDuration = '400ms';
        });

        nextButton.addEventListener('mouseleave', function () {
            nextIcon.classList.remove('visible');
            popularList.style.transform = `translate3d(-${currentIndex * 284}px, 0px, 0px)`;
            popularList.style.transitionDuration = '400ms';
        });
    }
});
