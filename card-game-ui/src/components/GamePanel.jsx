import React, { useState } from "react";
import '../style/GameTable.css';

export default function CardTable() {
    const [scores, setScores] = useState({});
    const [loading, setLoading] = useState(false);
    const [gameStarted, setGameStarted] = useState(false);
    const [gameId, setGameId] = useState(null);

    const startGame = async () => {
        try {
            const response = await fetch("http://localhost:5173/api/Game/start", {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                }
            });
            
            if (!response.ok)
                {
                    throw new Error("Failed to start game");
                }
            
            const data = await response.json();
            setLoading(false);
            setScores(data.playerScores);
            setGameId(data.gameId);
            setGameStarted(true);
        } catch (error) {
            console.error("Error:", error);
            alert("Failed to start game");
        }
    };

    const endGame = async () => {
            if (!gameId) 
                {
                    alert("No active game to end!");
                    return;
                }

            try {
                const response = await fetch(`http://localhost:5173/api/Game/end?gameId=${gameId}`, {
                method: "POST",
                headers: {
                    "Content-Type": "application/json",
                },
            });

                if (!response.ok) 
                    {
                        throw new Error("Failed to end game");
                    }
                    
                setGameId(null);
                setScores({});
                alert("Game ended successfully!");
            } catch (error) 
            {
                console.error(error);
                alert("Failed to end game");
            }
        }
    
    return (
        <div className="container">
            {!gameId && (
                <button onClick={startGame} disabled={loading}>
                    {loading ? "Starting..." : "Start Game"}
                </button>
            )}

            {gameId && (
                <button onClick={endGame}>End Game</button>
                )}

            <div style={{ height: "50px" }}></div>
            <div className="player">{`Player 1: ${scores["1"] ?? "-"}`}</div>

            <div className="row">
            <div className="player">{`Player 6: ${scores["6"] ?? "-"}`}</div>
            <div className="player">{`Player 2: ${scores["2"] ?? "-"}`}</div>
            </div>

            <div className="center-row">TABLE</div>

            <div className="row">
            <div className="player">{`Player 5: ${scores["5"] ?? "-"}`}</div>
            <div className="player">{`Player 3: ${scores["3"] ?? "-"}`}</div>
            </div>

            <div style={{ height: "50px" }}></div>
            <div className="player">{`Player 4: ${scores["4"] ?? "-"}`}</div>
        </div>
    );
}