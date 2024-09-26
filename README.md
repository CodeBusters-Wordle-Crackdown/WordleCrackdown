# Wordle-Crackdown
Fierce wordle game play in a fresh approach

# Detailed Instructions for Cloning GitHub Repository and Committing Unity WebGL Build to GitHub

## Part 1: Cloning a GitHub Repository in Visual Studio (Unity Project)

### Step 1: Open Visual Studio
1. Launch **Visual Studio**.
2. Go to the **Team Explorer** tab (you may find this on the View menu if it's not visible).
3. Click on **Clone** to clone a repository from GitHub.

### Step 2: Clone GitHub Repository
1. **Copy the repository URL** from GitHub (go to the repository on GitHub → Click the green **Code** button → Copy the HTTPS URL).
2. In **Team Explorer** → **Local Git Repositories**, select **Clone**.
3. **Paste the repository URL** into the clone URL field.
4. Choose a local directory on your machine where the repository will be cloned.
5. Click **Clone**.
6. Wait for Visual Studio to complete the cloning process. The Unity project files will now be available on your local machine.


## Part 2: Creating a New Branch from `dev`

### Step 1: Checkout the `dev` Branch
1. **Open the Team Explorer** tab in Visual Studio.
2. Go to **Branches**.
3. If you are not already on the `dev` branch, switch to it by right-clicking the **dev** branch and selecting **Checkout**.

### Step 2: Create a New Branch
1. After checking out the `dev` branch, click on **New Branch**.
2. Name your branch something meaningful (e.g., `feature/unity-webgl-build`).
3. Make sure the branch is based on `dev`.
4. Click **Create Branch**.
5. The new branch will now be available in your repository, and you can start working on it.


## Part 3: Creating a WebGL Build in Unity

### Step 1: Open Unity Project
1. Open the Unity Editor and load the project from the directory where you cloned the repository.

### Step 2: Open Build Settings
1. In Unity, go to **File** → **Build Settings**.
2. In the **Platform** section, select **WebGL**.
3. Click on **Switch Platform** (if it’s not already set to WebGL). This will make WebGL the target platform.

### Step 3: Create the WebGL Build
1. Click **Player Settings** and review the settings for WebGL if needed (optional, but recommended).
2. Click **Build**.
3. Select a folder (e.g., `WebGLBuild`) in your local repository to save the WebGL files.
4. Wait for Unity to finish building the project.

### Step 4: Verify Build
1. Check the folder where you built the WebGL files. It should contain `index.html` and other WebGL-related files (e.g., `.js` files, `data` files).
2. This folder is crucial for deploying your game online.

---

## Part 4: Committing Unity Files to GitHub (Including WebGL Build)

### Step 1: Stage Changes
1. Open **Team Explorer** in Visual Studio.
2. Go to the **Changes** tab.
3. Make sure the following folders are being tracked by Git (they should not be ignored):
   - `Assets`
   - `Packages`
   - `ProjectSettings`
   - `UserSettings`
   - `WebGLBuild` (or whatever you named the WebGL output folder)

### Step 2: Exclude Unnecessary Files
1. Ensure unnecessary folders like `Library`, `Temp`, `Builds`, and any large files are not being tracked.
2. If necessary, update the `.gitignore` file to exclude these files.

### Step 3: Commit Your Changes
1. In the **Changes** tab, select the files/folders you want to commit.
2. Write a meaningful commit message (e.g., "Add Unity WebGL Build and project files").
3. Click **Commit All**.

### Step 4: Push Your Changes to GitHub
1. Go to **Team Explorer** → **Sync**.
2. Click **Push** to push your committed changes to the remote branch.

### Step 5: Create a Pull Request (Optional but recommended)
1. On GitHub, create a pull request to merge your branch into `dev` when your feature is complete.
2. Add your team members as reviewers.

---

## Summary
This guide shows you how to:
1. Clone a Unity project from GitHub to Visual Studio.
2. Create a new branch off `dev`.
3. Create a WebGL build in Unity.
4. Commit and push all relevant project files (including WebGL build) to GitHub.

Ensure you follow this process to ensure the correct Unity files and WebGL builds are committed to GitHub.


