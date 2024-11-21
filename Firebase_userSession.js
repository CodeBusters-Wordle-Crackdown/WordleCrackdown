firebase.auth().onAuthStateChanged((user) => {
    if (user) {
        // User is signed in
        console.log('User is signed in:', user.email);
        // Update UI accordingly, e.g., hide login button, show logout button
    } else {
        // User is signed out
        console.log('No user is signed in.');
        // Update UI accordingly
    }
});
