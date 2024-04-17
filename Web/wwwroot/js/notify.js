function ViewNotify(action, text) {
    const notifyPanel = document.querySelector('.notify-panel');

    const notifyBlock = document.createElement('div');
    notifyBlock.innerHTML = `
    <div class="notify">
        <div>${action}:</div>
        <div>${text}</div>
    </div>
    `;


    const notify = notifyBlock.querySelector('.notify');

    notify.addEventListener('click', function () {
        deleteNotify();
    });

    notifyPanel.appendChild(notifyBlock);
    setTimeout(() => {
        notify.style.pointerEvents = 'auto';
        notify.style.opacity = '0.95';
        notify.style.transform = 'translateY(0px) scale(1)';
    }, 10);

    setTimeout(() => {
        if (notify !== null && notify !== undefined) {
            deleteNotify();
        }
    }, 4000);

    function deleteNotify() {
        notify.style.pointerEvents = 'none';
        notify.style.opacity = '0';
        notify.style.transform = 'translateY(-100%) scale(0.8)';
        setTimeout(() => {
            notifyBlock.remove();
        }, 250);
    }
}