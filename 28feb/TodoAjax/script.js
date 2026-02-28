// wwwroot/js/script.js

const xhr = new XMLHttpRequest();
const url = 'https://jsonplaceholder.typicode.com/todos';

xhr.onload = function () {
    if (xhr.status >= 200 && xhr.status < 300) {
        console.log('Success:', JSON.parse(xhr.responseText));
    } else {
        console.error('Error:', xhr.status, xhr.statusText);
    }
};

xhr.onerror = function () {
    console.error('Network Error');
};

xhr.open('GET', url, true);
xhr.send();