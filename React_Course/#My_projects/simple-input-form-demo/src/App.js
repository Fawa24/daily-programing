import { useState } from "react";

function App() {
  const[isDisplayed, setIsDisplayed] = useState(true)

  const content = <div>
    <h3>Hello, User!</h3>
    <p>This is some random content</p>
  </div>

  function handleOnClick() {
    setIsDisplayed(wasDisplayed => !wasDisplayed)
  }

  return (
    <div>
      <button onClick={handleOnClick}>Click me</button>
      {isDisplayed ? content : undefined}
    </div>
  );
}

export default App;
