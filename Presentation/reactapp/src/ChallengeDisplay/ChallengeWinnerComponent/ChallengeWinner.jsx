import React from "react";
import styles from "./ChallengeWinner.module.css";
import ChallengeImage from "../ChallengeImageComponent/ChallengeImage";
import ChallengeBuyIcon from "../ChallengeBuyIconComponent/ChallengeBuyIcon";
import "../../fonts.css";

const ChallengeWinner = (props) => {
  const { recipe, colour } = props;
  const { title } = recipe;
  console.log(title);

  return (
    <div className={styles.ChallengeWinner} style={{ backgroundColor: colour }}>
      <ChallengeImage recipe={recipe} />
      <img
        src="src/Resource_images/Winner_Icon.svg"
        className={styles.WinnerIcon}
      />
      <ChallengeBuyIcon />
      <p className={styles.RecipeTitle}>{title}</p>
    </div>
  );
};

export default ChallengeWinner;
