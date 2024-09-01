const adjectivesArray = ['Fundamental', 'Crucial', 'Core'];
import reactImage from './assets/react-core-concepts.png'

function getRandomAdjective() {
  let index = Math.floor(Math.random() * (adjectivesArray.length));
  return (adjectivesArray[index]);
}

function App() {
  return (
    <div>
      <Header />
      <main>
        <h2>Time to get started!</h2>
      </main>
    </div>
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
