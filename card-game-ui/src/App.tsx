import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import GamePanel from "./components/GamePanel.jsx";

function App() {
  return (
    <div>
      <div className="min-h-screen bg-gray-100 flex items-center justify-center">
        <GamePanel />
      </div>
    </div>
  );
}

export default App
