import ChallengeRow from "./ChallengeRow";
import ChallengeWinner from "../ChallengeWinnerComponent/ChallengeWinner";
import ChallengeBackgroundSquare from "../ChallengeBackgroundComponent/ChallengeBackgroundSquare";
import { useEffect, useState } from "react";

const ChallengeRowDiv = ({ challenge }) => {
  const recipes = challenge.recipes;

  const [backgroundColour, setBackgroundColour] = useState("");

  //random achtergrondkleur instellen
  const getRandomNumber = (min, max) => {
    return Math.floor(Math.random() * (max - min + 1)) + min;
  };
  useEffect(() => {
    const red = getRandomNumber(5, 255);
    const green = getRandomNumber(5, 255);
    const blue = getRandomNumber(5, 255);

    setBackgroundColour(`rgb(${red},${green},${blue}`);
  }, []);
  return (
    <div>
      <ChallengeRow colour={backgroundColour} challenge={challenge}>
        {recipes.length > 0 && (
          <ChallengeWinner
            colour={`${backgroundColour}, 0.1`}
            recipe={recipes[0]}
          />
        )}
        {recipes.slice(1).map((recipe, index) => (
          <ChallengeBackgroundSquare
            colour={`${backgroundColour}, 0.3`}
            key={index}
            recipe={recipe}
          />
        ))}
      </ChallengeRow>
    </div>
  );
};

export default ChallengeRowDiv;
