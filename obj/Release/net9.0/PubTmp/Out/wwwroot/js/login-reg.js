const container = document.querySelector('.container');
const LoginLink = document.querySelector('.SignInLink');
const RegisterLink = document.querySelector('.SignUpLink');

// Toggle Forms
if (RegisterLink && container) {
    RegisterLink.addEventListener('click', () => {
        container.classList.add('active');
    });
}

if (LoginLink && container) {
    LoginLink.addEventListener('click', () => {
        container.classList.remove('active');
    });
}

// Login Validation
const loginForm = document.getElementById('login-form');
const loginEmail = document.getElementById('email');
const loginPassword = document.getElementById('password');
const loginError = document.getElementById('error-msg');

if (loginForm) {
    loginForm.addEventListener('submit', function (e) {
        if (!validateForm(loginEmail, loginPassword, loginError)) {
            e.preventDefault();
        }
    });
}

// Register Validation
const registerForm = document.getElementById('register-form');
const registerEmail = document.getElementById('reg-email');
const registerPassword = document.getElementById('reg-password');
const registerUsername = document.getElementById('reg-username');
const registerError = document.getElementById('register-error-msg');

if (registerForm) {
    registerForm.addEventListener('submit', function (e) {
        let valid = true;
        if (!registerUsername.value.trim()) {
            registerError.textContent = "Username is required.";
            valid = false;
        }
        if (!validateForm(registerEmail, registerPassword, registerError)) {
            valid = false;
        }

        if (!valid) {
            e.preventDefault();
        }
    });
}

// Reusable Validation Function
function validateForm(emailField, passwordField, errorBox) {
    const email = emailField.value.trim();
    const password = passwordField.value.trim();

    if (!email || !password) {
        errorBox.textContent = "Please fill in all fields.";
        return false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (!emailRegex.test(email)) {
        errorBox.textContent = "Please enter a valid email.";
        return false;
    }

    if (password.length < 6) {
        errorBox.textContent = "Password must be at least 6 characters.";
        return false;
    }

    errorBox.textContent = "";
    return true;
}
