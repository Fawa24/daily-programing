import { useState } from "react";

function App() {
  const[contentNumber, setContentNumber] = useState(1)

  const content1 = <div>
    <h3>Hello, User!</h3>
    <p>This is some random content for the first button</p>
  </div>

  const content2 = <div>
    <h3>Hello again, User!</h3>
    <p>Hope you enjoy the first content block. Now you are welcome to stay there, on the bsecond block!</p>
  </div>

  const content3 = <div>
    <h3>Hello one more time, User!</h3>
    <p>Welcome to the third content block, the last one</p>
  </div>

  function renderContent() {
    switch (contentNumber) {
      case 1:
        return content1;
      case 2:
        return content2;
      case 3:
        return content3;
      default:
        return undefined;
    }
  }

  function handleOnClick(content) {
    setContentNumber(content)
  }

  return (
    <div>
      <button onClick={() => handleOnClick(1)}>Content 1</button>
      <button onClick={() => handleOnClick(2)}>Content 2</button>
      <button onClick={() => handleOnClick(3)}>Content 3</button>
      {renderContent()}
    </div>
  );
}

export default App;
