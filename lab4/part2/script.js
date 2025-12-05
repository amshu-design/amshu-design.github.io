const displayedImage = document.querySelector(".displayed-img");
const thumbBar = document.querySelector(".thumb-bar");

const btn = document.querySelector("button");
const overlay = document.querySelector(".overlay");

// create array of objects called images.
const images = [
{ filename: "pic1.jpg", alt: "Close-up of a human eye" },
{ filename: "pic2.jpg", alt: "Rock that looks like a wave" },
{ filename: "pic3.jpg", alt: "Purple and white pansies" },
{ filename: "pic4.jpg", alt: "Section of wall from a pharaoh's tomb" },
{ filename: "pic5.jpg", alt: "Large moth on a leaf" },
];

// Base URL for images
const baseURL = "https://mdn.github.io/shared-assets/images/examples/learn/gallery/pic1.jpg";

// Looping through images array
for (const image of images) {
  const newImage = document.createElement("img");
 
  newImage.src = baseURL + image.filename;
  newImage.alt = imgData.alt;
  
  // Make the image focusable via the keyboard
  newImage.tabIndex = "0";

  // Append the image as a child of the thumbBar
  thumbBar.appendChild(newImage);

  // Update the display to show the image full size when a thumb is clicked
  newImage.addEventListener("click", updateDisplayedImage);

  // Update the display to show the image full size when a thumb is focused and Enter is pressed
  newImage.addEventListener("keydown", function (e) {
    if (e.key === "Enter") {
      updateDisplayedImage.call(newImage);
    }
  });
}


