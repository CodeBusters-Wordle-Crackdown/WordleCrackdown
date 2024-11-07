# Wordle-Crackdown
Fierce wordle game play in a fresh approach

https://codebusters-wordle-crackdown.github.io/WordleCrackdown/

# Detailed Instructions to Incorporate WebFront in your local device

Assuming you have everything linked to your own device here is the steps you need to follow in order to make this work in the command line.

## 1 Step: Create switch to this branch using "git checkout devWebFront"

Now you are in the branch with all these files

## 2 Step: Move to CodeBustersWeb folder by typing "cd CodeBustersWeb"

This ensures you make the next step inside the folder

## 3 Step: Install Node.js and run "npm install"

For this step is crucial you download the lastes version or a Long Term Service version of Node.js

## 4 Step: Install Node.js and run "npm i @react-spring/parallax"

This module provides a physics based spring like parallax animation.

### Modifying Parallax & Propperties

React spring parallax adds an element named Parallax which includes a property pages that adds working space in the body/canvas with respect to the device being use. While using it, it messes with the Z-index, so instead it adds an element ParallaxLayer, which has properties offset, to indicate layers or position, and speed, that species how fast it should move. Be aware that ParallaxLayer should be always inside the Parallax element in order to work.

## 5 Step: Install Node.js and run "npm i react-router-dom"
This module provides a physics based spring like parallax animation.

## 6 Step: Finally run "npm run dev"

This will give you a localhost address where the website will be appering, just copy a and paste
this address and this will show the current state of the website.

## n Step (optional): Building a Static Website with React

So far we have running to develop, but if you want to test how it works in reality with a hosting website you'll have to create a static page. For this you'll have to run "npm build" once you have all dependencies attached. This will create a compressed version of the website.
