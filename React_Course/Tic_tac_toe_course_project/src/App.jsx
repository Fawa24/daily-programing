import { useState } from "react"
import GameBoard from "./components/GameBoard"
import Player from "./components/Player"
import Log from "./components/Log";

function App() {
  const[activePlayer, setActivePlayer] = useState('X');
  const[gameTurns, setGameTurns] = useState([]);

  function handleSelectSquare(rowIndex, columnIndex) {
    setActivePlayer((curActivePlayer) => curActivePlayer === 'X' ? 'O' : 'X');
    setGameTurns(prevTurns => {
      let currentPlayer = 'X'

      if(prevTurns.length > 0 && prevTurns[0].pla === 'X') {
        currentPlayer = 'O';
      }

      const updTurns = [{ square: {row: rowIndex, col: columnIndex }, player: activePlayer }, ...prevTurns]

      return updTurns;
    })
  }

  return (
    <main>
      <div id="game-container">

        <ol id="players" className="highlight-player">
          <Player initialName="Player-1" symbol="X" isActive={activePlayer === 'X' ? true : false}/>
          <Player initialName="Player-2" symbol="O" isActive={activePlayer === 'O' ? true : false}/>
        </ol>

        <GameBoard onSelectSquare={handleSelectSquare} turns={gameTurns}/>
        
      </div>
      <Log turns={gameTurns}/>
    </main>
  )
}

export default App
