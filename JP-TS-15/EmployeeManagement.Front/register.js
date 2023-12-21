let email = document.querySelector('#email');
let password = document.querySelector('#password');
let registerForm = document.querySelector('#registerForm')

function registerUser(email, password) {
    const body = {
        "email": email,
        "password": password,
    };

    fetch('https://localhost:7069/api/auth/register', {
        method: 'POST',
        body: JSON.stringify(body),
        headers: {
            'content-type': 'application/json'
        }
    })
        .then(response => response.json()) // Need to invoke json() to parse the response
        .then(data => {
            console.log(data);
            if (data.isSuccess) {
                alert('User registered successfully');
                window.location.href = '/index.html';
            }
            else{
                alert('Can not registr user');
            }
        })
        .catch(error => console.error('Error:', error)); // Catch any errors
}


registerForm.addEventListener('submit', function (e) {
    e.preventDefault();
    registerUser(email.value,password.value)
});