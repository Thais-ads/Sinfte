function exibirNotificacao() {
    if ('Notification' in window && Notification.permission === 'granted') {
        const options = {
            body: 'Esta é uma notificação de exemplo.',
            icon: 'caminho-para-o-icone.png'
        };

        new Notification('Título da Notificação', options);
    }
}

// Solicitar permissão para exibir notificações
if ('Notification' in window && Notification.permission !== 'granted') {
    Notification.requestPermission();
}