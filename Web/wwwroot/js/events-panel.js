document.querySelectorAll('.events-item').forEach(item => {
    item.addEventListener('click', function() {
        const isFlipped = this.classList.contains('flipped');
        document.querySelectorAll('.events-item').forEach(el => {
            const slideText = el.querySelector('.events-slide-text');
            const title = slideText.querySelector('.events-title');
            const text = slideText.querySelector('.events-text');

            setTimeout(() => {
                text.style.display = 'none';
                title.style.display = 'block';
                el.querySelector('.events-image').style.filter = 'none';
            }, 130);

            el.classList.remove('flipped');
        });
        if (!isFlipped) {
            this.classList.add('flipped');
        }

        const slideText = this.querySelector('.events-slide-text');
        const title = slideText.querySelector('.events-title');
        const text = slideText.querySelector('.events-text');

        setTimeout(() => {
            if (isFlipped) {
                    text.style.display = 'none';
                    title.style.display = 'block';
                    this.querySelector('.events-image').style.filter = 'none';
                
            } else {
                text.style.display = 'block';
                title.style.display = 'none';
                this.querySelector('.events-image').style.filter = 'blur(8px)';
            }
        }, 130);
    });
});




document.addEventListener('DOMContentLoaded', function() {
    const eventsPanel = document.querySelector('.panel[data-type="events"]');

    const prevButton = eventsPanel.querySelector('.item.prev');
    const nextButton = eventsPanel.querySelector('.item.next');
    const eventsList = eventsPanel.querySelector('.events-list');
    const eventsItems = eventsPanel.querySelectorAll('.events-item');
    
    let countMax = Math.round(parseFloat(getComputedStyle(eventsList).width) / 205.2) - 1;
    let currentIndex = 0;

    if (eventsItems.length > 0 && eventsItems[0] !== null && eventsItems[0] !== undefined) {
        const firstPopularItem = eventsItems[0];
        firstPopularItem.classList.add('selected');


        window.addEventListener('resize', function () {
            countMax = Math.round(parseFloat(getComputedStyle(eventsList).width) / 205.2) - 1;

            if (!(currentIndex < eventsItems.length - countMax)) {
                currentIndex = eventsItems.length - countMax;
                eventsList.style.transform = `translate3d(-${currentIndex * 205.2}px, 0px, 0px)`;
            }
            if (currentIndex >= 0)
                markSelected(currentIndex);
        });


        function markSelected(index) {
            eventsItems.forEach(item => item.classList.remove('selected'));
            eventsItems[index].classList.add('selected');
        }

        function next() {
            if (currentIndex > 0 && currentIndex < eventsItems.length - countMax) {
                currentIndex++;
                eventsList.style.transform = `translate3d(-${currentIndex * 205.2}px, 0px, 0px)`;
                markSelected(currentIndex);
            }
        }

        function prev() {
            if (currentIndex > 0) {
                currentIndex--;
                eventsList.style.transform = `translate3d(-${currentIndex * 205.2}px, 0px, 0px)`;
                markSelected(currentIndex);
            }
        }

        prevButton.addEventListener('click', prev);
        nextButton.addEventListener('click', next);
    }
});