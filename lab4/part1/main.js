/*
          Name: Amshika Gautam
          File: index.html
          Date: 3 December 2023
          Lab 4 ` Part 1 - Silly story genearator
        */
const customName = document.getElementById("custom-name");
const generateBtn = document.querySelector(".generate");
const story = document.querySelector(".story");

function randomValueFromArray(array) {
  const random = Math.floor(Math.random() * array.length);
  return array[random];
}

// Raw text strings
const characters = [
  "Willy the Goblin",
  "Big Daddy",
  "Father Christmas",
];
const places = [
  "the soup kitchen",
  "Disneyland",
  "the White House",
];
const events = ["spontaneously combusted",
  "melted into a puddle on the sidewalk",
  "turned into a slug and slithered away",
];


// spontaneously combusted
// melted into a puddle on the sidewalk
// turned into a slug and slithered away

// Partial return random string function

function returnRandomStoryString() {
  // It was 94 Fahrenheit outside, so :insertx: went for a walk. When they got to :inserty:, they stared in horror for a few moments, then :insertz:. Bob saw the whole thing, but was not surprised — :insertx: weighs 300 pounds, and it was a hot day.
  const randomCharacter = randomValueFromArray(characters);
  const randomPlace = randomValueFromArray(places);
  const randomEvent = randomValueFromArray(events);
  let storyText = `It was 94 Fahrenheit outside,
   so ${randomCharacter} went for a walk. When they got to ${randomPlace},
    they stared in horror for a few moments, then ${randomEvent}. 
    Bob saw the whole thing, but was not surprised — ${randomCharacter}
     weighs 300 pounds, and it was a hot day.`;
  return storyText;
}

// Event listener and partial generate function definition

generateBtn.addEventListener("click", generateStory);

function generateStory() {
  let newStory = returnRandomStoryString();
  
  if (customName.value !== "") {
    const name = customName.value;
    newStory = newStory.replace("Bob", name);

  }

  if (document.getElementById("uk").checked) {
    const weight = `${Math.round(300 / 14.5833)} stone`;
    const temperature = `${Math.round(94 - 32) * 5 / 9} celsius`;
    newStory = newStory.replace("300 pounds", weight);
    newStory = newStory.replace("94 Fahrenheit", temperature);

  }

  // TODO: replace "" with the correct expression
  story.textContent = newStory;
  story.style.visibility = "visible";
}