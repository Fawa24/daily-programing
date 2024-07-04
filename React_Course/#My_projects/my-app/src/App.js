import { useState } from 'react';
import './App.css';

function App() {
  const [text, setText] = useState('Default value')

  function handleChange(event) {
    setText(event.target.value)
  }

  return (
    <div>
      <input type='text' defaultValue={text} onChange={handleChange} />
      <p>Current text: {text}</p>
    </div>
  );
}

export default App;
