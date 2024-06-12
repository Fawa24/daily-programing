import { CORE_CONCEPTS } from './data.js';
import { Header } from './components/Header/Header.jsx';
import CoreConcept from './components/CoreConcept.jsx';
import TabButton from './components/TabButton/TabButton.jsx';
import { useState } from 'react';

function App() {
  let [ selectedTopic, setSelectedTopic ] = useState('Please click a button');

  function handleClick(selectedButton) {
    setSelectedTopic(selectedButton)
  }

  return (
    <div>
      <Header></Header>
      <main>

        <section id="core-concepts">

          <h2>Core Concepts</h2>
          <ul>
            <CoreConcept {...CORE_CONCEPTS[0]} />
            <CoreConcept {...CORE_CONCEPTS[1]} />
            <CoreConcept {...CORE_CONCEPTS[2]} />
            <CoreConcept {...CORE_CONCEPTS[3]} />
          </ul>
        </section>

        <section id="examples">
          <h2>Examples</h2>
          <menu>
            <TabButton onClick={() => handleClick("Component")}>Component</TabButton>
            <TabButton onClick={() => handleClick("JSX")}>JSX</TabButton>
            <TabButton onClick={() => handleClick("Props")}>Props</TabButton>
            <TabButton onClick={() => handleClick("State")}>State</TabButton>
          </menu>
          {selectedTopic}
        </section>

      </main>
    </div>
  );
}

export default App;
