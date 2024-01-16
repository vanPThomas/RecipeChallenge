import React, { useState, useEffect } from "react";
import styles from "./FoodTinderAppDisplay.module.css";
import topImage from "../Resource_images/Ellipse_Like.svg";
import bottomImage from "../Resource_images/Ellipse_Dislike.svg";
import centerBackground from "../Resource_images/screen.svg";
import "../fonts.css";
import TinderRecipeComponent from "./TinderRecipeComponent/TinderRecipeComponent";
import { fetchChallenges } from "../api/ChallengeApi";

const FoodTinderAppDisplay = () => {
  const [challenges, setChallenges] = useState([]);
  const [challenge, setChallenge] = useState(null);

  useEffect(() => {
    const fetchData = async () => {
      //get all challenges
      const data = await fetchChallenges();
      setChallenges(data);
    };

    fetchData();
  }, []);

  useEffect(() => {
    const newChallenge = challenges[0];
    setChallenge(newChallenge);
  }, [challenges]);

  return (
    <div className={styles.TinderMainDisplay}>
      <div className={styles.TinderWindow}>
        <div className={styles.TinderHeader}>
          <h2>Food Tinder!</h2>
          <h3>Stem op je favoriete recepten</h3>
        </div>
        <div className={styles.InteractiveWindow}>
          <div className={styles.topImage}>
            <img src={topImage} />
          </div>
          <div className={styles.centerImage}>
            <div className={styles.centerImageLeft}>
              <img src={centerBackground} className={styles.screen} />
              <img src={centerBackground} className={styles.screen} />
            </div>
            <div className={styles.centerDivider}></div>
            <div className={styles.centerImageRight}>
              <img src={centerBackground} className={styles.screen} />
              <img src={centerBackground} className={styles.screen} />
            </div>
          </div>
          <div className={styles.bottomImage}>
            <img src={bottomImage} />
          </div>
          <div className={styles.RecipeOverlay}>
            {challenge && (
              <TinderRecipeComponent
                className={styles.TinderComponent}
                challenge={challenge}
              />
            )}
          </div>
        </div>
      </div>
    </div>
  );
};

export default FoodTinderAppDisplay;
