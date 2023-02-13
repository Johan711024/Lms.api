import React from 'react';
import { Game } from '../features/game/Game'
import { Counter } from '../features/counter/Counter'


import styles from './App.module.css'

function App() {
    return (
        <div className={ styles.Container }>
           
            <Game />
            
      </div>
  );
}

export default App;
