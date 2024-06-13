import { useState } from 'react';
import { EXAMPLES } from '../../data-with-examples.js'
import Section from '../Section/Section.jsx';
import Tabs from '../Tabs/Tabs.jsx';
import TabButton from '../TabButton/TabButton.jsx';

export default function Examples() {
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

    return(
        <Section title="Examples" id="examples">
          <Tabs buttons={<>
            <TabButton isClicked={selectedTopic === 'components'} onClick={() => handleClick("components")}>Components</TabButton>
            <TabButton isClicked={selectedTopic === 'jsx'} onClick={() => handleClick("jsx")}>JSX</TabButton>
            <TabButton isClicked={selectedTopic === 'props'} onClick={() => handleClick("props")}>Props</TabButton>
            <TabButton isClicked={selectedTopic === 'state'} onClick={() => handleClick("state")}>State</TabButton></>}>
            {tabContent}
          </Tabs>                 
        </Section>
    )
}