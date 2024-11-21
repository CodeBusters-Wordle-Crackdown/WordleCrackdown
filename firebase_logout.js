const logoutBtn = document.getElementById("logoutBtn");
logoutBtn.addEventListener("click", () => {
    firebase.auth().signOut()
        .then(() => {
            console.log('User signed out.');
            // Update UI accordingly
        })
        .catch((error) => {
            console.error('Sign out error:', error);
        });
});
