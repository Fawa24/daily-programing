const adjectivesArray = ['Fundamental', 'Crucial', 'Core'];
import reactImage from './assets/react-core-concepts.png';
import { CORE_CONCEPTS } from './CoreComponents.js'

function getRandomAdjective() {
  let index = Math.floor(Math.random() * (adjectivesArray.length));
  return (adjectivesArray[index]);
}

function App() {
  return (
    <div>
      <Header />
      <main>
        <section id='core-concepts'>
          <h2>Concepts</h2>
          <ul>
            <CoreConcept {...CORE_CONCEPTS[0]}/>
            <CoreConcept {...CORE_CONCEPTS[1]}/>
            <CoreConcept {...CORE_CONCEPTS[2]}/>
            <CoreConcept {...CORE_CONCEPTS[3]}/>
          </ul>
        </section>
        <h2>Time to get started!</h2>
      </main>
    </div>
  );
}

function CoreConcept({title, description, image}) {
  return(
    <li>
      <img src={image} alt=''/>
      <h3>{title}</h3>
      <p>{description}</p>
    </li>
  );
}

function Header() {
const description = getRandomAdjective();

  return(
    <header>
        <img src={reactImage} alt="Stylized atom" />
        <h1>React Essentials</h1>
        <p>
          {description} React concepts you will need for almost any app you are
          going to build!
        </p>
      </header>
  );
}

export default App;
