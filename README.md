# Wordle-Crackdown
Fierce wordle game play in a fresh approach

https://codebusters-wordle-crackdown.github.io/WordleCrackdown/
*Unity version 2022.3.45f1*

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
7. Open UnityHub and Click Add
8. In the dropdown menu, select add new project from disk, then select the folder you just cloned


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

# Step-by-Step Guide for Unity Development with GitHub and Visual Studio

## Part 1: Opening Visual Studio and Creating a New Unity Project

### Step 1: Open Visual Studio
1. Open **Visual Studio** from your Start Menu or application launcher.
2. Once Visual Studio is open, select **Create a New Project**.

### Step 2: Create a New Unity Project
1. In Visual Studio, select **Unity** as the project template (make sure you have installed the Unity tools for Visual Studio).
2. Choose a project location and give the project a name (e.g., `MyUnityGame`).
3. Click **Create** to create the Unity project.
4. **Verify** that the Unity project opens successfully in Visual Studio. It should have folders like **Assets**, **Packages**, **ProjectSettings**, etc.

---

## Part 2: Cloning the GitHub Repository into Visual Studio

### Step 1: Clone the GitHub Repository
1. In Visual Studio, open the **Team Explorer** tab (View > Team Explorer if it’s not visible).
2. Click on **Clone** to clone a GitHub repository.
3. Copy the repository URL from GitHub (go to the repository page on GitHub, click **Code**, and copy the HTTPS URL).
4. Paste the URL into the **Repository Location** field in Visual Studio.
5. Choose a folder where the repository will be cloned on your local machine.
6. Click **Clone**.
7. **Verify** that the Unity project and files are successfully cloned to your machine.

---

## Part 3: Creating a Branch from the `dev` Branch

### Step 1: Check Out the `dev` Branch
1. In **Team Explorer** (in Visual Studio), go to **Branches**.
2. If you’re not already on the `dev` branch, right-click on `dev` and select **Checkout**.
3. **Verify** that you are now on the `dev` branch by checking the branch name in the bottom right corner of Visual Studio.

### Step 2: Create a New Branch
1. In **Team Explorer**, click **New Branch**.
2. Name the new branch something meaningful (e.g., `feature/webgl-build`). Ensure it is based on the `dev` branch.
3. Click **Create Branch**.
4. **Verify** that the new branch has been created by checking the branch name (bottom right corner or in the **Branches** tab).

---

## Part 4: Creating a WebGL Build in Unity

### Step 1: Open Unity from Visual Studio
1. Open the Unity Editor from within Visual Studio (you can find Unity under **Solution Explorer** or in your project folder).
2. In Unity, open the project from the directory where you cloned the repository.

### Step 2: Build the Project for WebGL
1. In Unity, go to **File** → **Build Settings**.
2. In the **Platform** section, select **WebGL**.
3. Click **Switch Platform** to change the target platform to WebGL.
4. Click **Build**, and choose a folder in the repository (e.g., `WebGLBuild`) to store the build files.
5. **Verify** that the WebGL build completes and creates files like `index.html` and other WebGL-related files.

---

## Part 5: Committing Files to GitHub

### Step 1: Stage and Commit Changes
1. Go to **Team Explorer** → **Changes**.
2. Ensure the following folders are staged for commit:
   - `Assets`
   - `Packages`
   - `ProjectSettings`
   - `UserSettings`
   - **WebGL build folder** (e.g., `WebGLBuild`)
3. If necessary, update the `.gitignore` file to exclude unnecessary files (like `Library` or `Temp` folders).

### Step 2: Write a Commit Message
1. Write a descriptive commit message (e.g., "Add WebGL build and project settings").
2. Click **Commit All**.
3. **Verify** that the commit includes the correct files by reviewing the commit in the **Changes** tab or on GitHub after you push.

### Step 3: Push to GitHub
1. Go to **Team Explorer** → **Sync**.
2. Click **Push** to push your branch to the remote repository.
3. **Verify** on GitHub that the branch and files were pushed correctly.

---

## Part 6: Verifying and Merging the Branch with Other Branches

### Step 1: Check the New Branch on GitHub
1. Go to GitHub and check that the new branch you created (e.g., `feature/webgl-build`) exists and that all the necessary files have been uploaded.
2. Ensure that the WebGL build folder, `Assets`, `Packages`, and other files have been uploaded correctly.

### Step 2: Create a Pull Request (PR)
1. On GitHub, create a pull request (PR) to merge your feature branch into the `dev` branch.
2. Add your team members as reviewers.
3. **Verify** that the pull request includes all the relevant files and changes.

### Step 3: Merge the Branch
1. Once the PR is approved, merge your branch into `dev`.
2. **Verify** that the branch has been successfully merged, and the `dev` branch contains the new WebGL build and other files.
3. After testing in `dev`, follow the same process to merge `dev` into `test` or `main` (prod) as needed.

---

## Summary
This guide covers:
1. Opening Visual Studio and creating a Unity project.
2. Cloning a GitHub repository.
3. Creating a new branch from `dev`.
4. Building WebGL in Unity.
5. Committing and pushing changes to GitHub.
6. Verifying branch contents and merging branches.

Ensure these steps are followed carefully to maintain consistent workflows and avoid missing files.

