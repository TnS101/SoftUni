function solve() {
    document.getElementById('send').addEventListener('click', function execute() {
        let input = document.getElementById('chat_input');
        let newMessage = document.createElement('div');
        newMessage.className = 'message my-message';
        newMessage.textContent = input.value;

        let parrentDiv = document.getElementById('chat_messages');

        parrentDiv.appendChild(newMessage);
        input.value = '';
    })
}