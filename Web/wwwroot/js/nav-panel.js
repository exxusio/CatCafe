const nav = document.querySelector('.nav');
const header = document.querySelector('.header');
const infoPanel = document.querySelector('.info-panel');
const logo = document.querySelector('.logo');
const navList = document.querySelector('.nav-list');

const headerHeight = header.offsetHeight + infoPanel.offsetHeight - 1;
let isScrolled = false;
let placeholder = null;

function createPlaceholder() {
    placeholder = document.createElement('div');
    placeholder.classList.add('nav-placeholder');
    header.parentNode.insertBefore(placeholder, header.nextSibling);
    placeholder.style.minHeight = nav.offsetHeight + 'px';
}


function handleScroll() {
    if (window.scrollY > headerHeight) {
        if (!isScrolled) {
            createPlaceholder();
            nav.classList.add('fixed');
            logo.classList.add('visible');
            navList.classList.add('shifted');
            isScrolled = true;
        }
    } else {
        if (isScrolled) {
            nav.classList.remove('fixed');
            logo.classList.remove('visible');
            navList.classList.remove('shifted');
            placeholder.remove();
            isScrolled = false;
        }
    }
}

window.addEventListener('scroll', handleScroll);

document.addEventListener('DOMContentLoaded', function() {
    var links = document.querySelectorAll('a.items[data-type="list"]');
    var offset = 50;
    links.forEach(function(link) {
        link.addEventListener('click', function(event) {
            event.preventDefault();
            var target = this.getAttribute('href');
            var targetElement = document.querySelector(target);
            if (targetElement) {
                var targetPosition = targetElement.getBoundingClientRect().top + window.pageYOffset - offset;
                window.scrollTo({ top: targetPosition, behavior: 'smooth' });
            }
        });
    });
});


document.addEventListener('DOMContentLoaded', function() {
    const searchBox = document.getElementById('search-box');
    const notification = (document.querySelector('.search')).querySelector('.notification');

    searchBox.addEventListener('transitionend', function() {
        const computedWidth = getComputedStyle(searchBox).width;

        if (computedWidth === '40px' && searchBox.value.trim() !== '') {
            notification.style.opacity = '1';
            notification.classList.add('expand');
        } else {
            setTimeout(() => {
                notification.style.opacity = '0';
            }, 180);
            notification.classList.remove('expand');
        }
    });

    searchBox.addEventListener('transitionstart', function() {
        const computedWidth = getComputedStyle(searchBox).width;

        if (computedWidth !== '40px') {
            setTimeout(() => {
                notification.style.opacity = '0';
            }, 180);
            notification.classList.remove('expand');
        }
    });
});


document.addEventListener('DOMContentLoaded', function() {
    const cheapCheckbox = document.getElementById('cheap');
    const expensiveCheckbox = document.getElementById('expensive');

    cheapCheckbox.addEventListener('change', function() {
        if (cheapCheckbox.checked) {
            expensiveCheckbox.checked = false;
        }
    });

    expensiveCheckbox.addEventListener('change', function() {
        if (expensiveCheckbox.checked) {
            cheapCheckbox.checked = false;
        }
    });
});


document.getElementById('input-min').addEventListener('input', function(event) {
    let minMinValue = parseInt(event.target.getAttribute('min'));
    let minMaxValue = parseInt(document.getElementById('input-max').value);
    let minInputValue = parseInt(event.target.value);

    if (minInputValue < minMinValue) {
        event.target.value = minMinValue;
    }
    else if(minInputValue > 100) {
        event.target.value = minMaxValue - 10;
    }
});

document.getElementById('input-max').addEventListener('input', function(event) {
    let maxMinValue = parseInt(document.getElementById('input-min').value);
    let maxMaxValue = parseInt(event.target.getAttribute('max'));
    let maxInputValue = parseInt(event.target.value);

    if (maxInputValue < 0) {
        event.target.value = maxMinValue + 10;
    }
    else if(maxInputValue > maxMaxValue) {
        event.target.value = maxMaxValue;
    }
});

const rangeInput = document.querySelectorAll(".filter-range-input input"),
priceInput = document.querySelectorAll(".filter-input input"),
range = document.querySelector(".filter-slider .filter-progress");
let priceGap = 10;

priceInput.forEach(input =>{
    input.addEventListener("input", e =>{
        let minPrice = parseInt(priceInput[0].value),
        maxPrice = parseInt(priceInput[1].value);
        
        if((maxPrice - minPrice >= priceGap) && maxPrice <= rangeInput[1].max){
            if(e.target.id === "input-min"){
                rangeInput[0].value = minPrice;
                range.style.left = ((minPrice / rangeInput[0].max) * 100) + "%";
            }else{
                rangeInput[1].value = maxPrice;
                range.style.right = 100 - (maxPrice / rangeInput[1].max) * 100 + "%";
            }
        }
    });
});

rangeInput.forEach(input =>{
    input.addEventListener("input", e =>{
        let minVal = parseInt(rangeInput[0].value),
        maxVal = parseInt(rangeInput[1].value);

        if((maxVal - minVal) < priceGap){
            if(e.target.id === "range-min"){
                rangeInput[0].value = maxVal - priceGap
            }else{
                rangeInput[1].value = minVal + priceGap;
            }
        }else{
            priceInput[0].value = minVal;
            priceInput[1].value = maxVal;
            range.style.left = ((minVal / rangeInput[0].max) * 100) + "%";
            range.style.right = 100 - (maxVal / rangeInput[1].max) * 100 + "%";
        }
    });
});


document.addEventListener('DOMContentLoaded', function() {
    const filterButton = document.querySelector('.filter');
    const filterButtonCSS = document.querySelector('.filter-box');
    const filterButtonIcon = document.querySelector('.filter-icon');
    const filterPanel = document.querySelector('.filter-panel');

    const cheapCheckbox = document.getElementById('cheap');
    const expensiveCheckbox = document.getElementById('expensive');
    const inputMin = document.getElementById('input-min');
    const inputMax = document.getElementById('input-max');
    
    const notification = filterButton.querySelector('.notification');

    filterButton.addEventListener('click', function() {
        if(filterPanel.style.opacity === '0')
        {
            filterPanel.style.display = 'flex';
            filterButtonCSS.classList.add('pressed');
            filterButtonIcon.classList.add('pressed');
            setTimeout(() => {
                notification.style.opacity = '0';
            }, 180);
            notification.classList.remove('expand');
        }
        else
        {
            setTimeout(() => { filterPanel.style.display = 'none'; }, 300);
            filterButtonCSS.classList.remove('pressed');
            filterButtonIcon.classList.remove('pressed');

            if ((cheapCheckbox.checked || expensiveCheckbox.checked) || (parseInt(inputMin.value) !== 0 || parseInt(inputMax.value) !== 100))
            {
                setTimeout(() => {
                    notification.style.opacity = '1';
                    notification.classList.add('expand');
                }, 300);
            } else {
                setTimeout(() => {
                    notification.style.opacity = '0';
                }, 180);
                notification.classList.remove('expand');
            }  
        }

        setTimeout(() => {
            filterPanel.style.opacity = filterPanel.style.opacity === '0' ? '1' : '0';
            filterPanel.style.top = filterPanel.style.opacity === '0' ? '30px' : '60px';
        }, 100);
    });

    document.addEventListener('click', function(event) {
        const filterPanel = document.querySelector('.filter-panel');
    
        if (!event.target.closest('.filter-panel') && !event.target.closest('.filter')) {
            setTimeout(() => { filterPanel.style.display = 'none'; }, 300);
            filterButtonCSS.classList.remove('pressed');
            filterButtonIcon.classList.remove('pressed');
    
            if ((cheapCheckbox.checked || expensiveCheckbox.checked) || (parseInt(inputMin.value) !== 0 || parseInt(inputMax.value) !== 100))
            {
                setTimeout(() => {
                    notification.style.opacity = '1';
                    notification.classList.add('expand');
                }, 300);
            } else {
                setTimeout(() => {
                    notification.style.opacity = '0';
                }, 180);
                notification.classList.remove('expand');
            }
    
            setTimeout(() => {
                filterPanel.style.opacity = filterPanel.style.opacity === '0' ? '1' : '0';
                filterPanel.style.top = filterPanel.style.opacity === '0' ? '30px' : '60px';
            }, 100);
        }
    });
});