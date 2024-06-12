import { CORE_CONCEPTS } from './data.js';
import { Header } from './components/Header/Header.jsx';
import CoreConcept from './components/CoreConcept.jsx';
import TabButton from './components/TabButton/TabButton.jsx';
import { useState } from 'react';
import { EXAMPLES } from './data-with-examples.js';

function App() {
  let [ selectedTopic, setSelectedTopic ] = useState();

  function handleClick(selectedButton) {
    setSelectedTopic(selectedButton)
  }

  let tabContent = <p>Please select a topic using buttons above</p>

  if (selectedTopic) {
    tabContent = 
    <div id="tab-content">            
      <h3>{EXAMPLES[selectedTopic].title}</h3>
      <p>{EXAMPLES[selectedTopic].description}</p>
      <pre>
        <code>
          {EXAMPLES[selectedTopic].code}
        </code>
      </pre>
    </div>
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
            <TabButton isClicked={selectedTopic === 'components'} onClick={() => handleClick("components")}>Components</TabButton>
            <TabButton isClicked={selectedTopic === 'jsx'} onClick={() => handleClick("jsx")}>JSX</TabButton>
            <TabButton isClicked={selectedTopic === 'props'} onClick={() => handleClick("props")}>Props</TabButton>
            <TabButton isClicked={selectedTopic === 'state'} onClick={() => handleClick("state")}>State</TabButton>
          </menu>
          {tabContent}          
        </section>

      </main>
    </div>
  );
}

export default App;
