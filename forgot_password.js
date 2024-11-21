// Forgot Password functionality
const forgotPasswordBtn = document.getElementById("forgotPasswordBtn");

forgotPasswordBtn.addEventListener("click", () => {
    const email = document.getElementById("email").value;

    if (!email) {
        messageDiv.textContent = "Please enter your email address.";
        messageDiv.className = "error-message";
        return;
    }

    firebase.auth().sendPasswordResetEmail(email)
        .then(() => {
            messageDiv.textContent = "Password reset email sent! Check your inbox.";
            messageDiv.className = "success-message";
        })
        .catch((error) => {
            messageDiv.textContent = error.message;
            messageDiv.className = "error-message";
        });
});
