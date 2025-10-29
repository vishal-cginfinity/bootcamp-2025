const form = document.getElementById('item-form');
const input = document.getElementById('item-input');
const list = document.getElementById('item-list');

form.onsubmit = (e) => {
    e.preventDefault();
    if (input.value) {
        const li = document.createElement('li');
        li.innerHTML = `
            <span>${input.value}</span>
            <button onclick="this.parentElement.remove()">Delete</button>
        `;
        list.appendChild(li);
        input.value = '';
    }
};