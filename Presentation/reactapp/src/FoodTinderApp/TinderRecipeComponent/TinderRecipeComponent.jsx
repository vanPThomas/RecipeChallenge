import React, { useEffect, useState } from "react";
import styles from "./TinderRecipeComponent.module.css";
import likeThumb from "../../Resource_images/Vector_like.svg";
import dislikeThumb from "../../Resource_images/Vector_dislike.svg";
import { Link } from "react-router-dom";
import { addVoteToItem } from "../../api/ChallengeApi";

const TinderRecipeComponent = ({ challenge }) => {
  const [recipe, setRecipe] = useState(null);
  const [like, setLike] = useState(false);
  const [dislike, setDislike] = useState(false);
  const [moveRight, setMoveRight] = useState(false);
  const [index, setIndex] = useState(0);

  useEffect(() => {
    const newRecipe = challenge.recipes[index];
    console.log("set recipe");
    console.log(challenge);
    setRecipe(newRecipe);
  }, []);

  useEffect(() => {
    const newRecipe = challenge.recipes[index];
    setRecipe(newRecipe);
  }, [index]);

  const handleLike = async () => {
    setLike(true);
    console.log("Like clicked!");
    await addVoteToItem(challenge.recipes[index].id);
    let i = index;
    let updatedIndex = i + 1;

    setTimeout(() => {
      setIndex(updatedIndex);
      handleMoveRight();
      setLike(false);
    }, 500);
  };

  const handleDislike = () => {
    setDislike(true);
    console.log("Dislike clicked!");
    let i = index;
    let updatedIndex = i + 1;

    setTimeout(() => {
      setIndex(updatedIndex);
      handleMoveRight();
      setDislike(false);
    }, 500);
  };

  const handleMoveRight = () => {
    setMoveRight(true);

    setTimeout(() => {
      setMoveRight(false);
    }, 500);
  };

  return (
    <div className={styles.MainContainer}>
      <div className={styles.likeContainer}>
        <Link onClick={handleLike}>
          <img src={likeThumb} className={styles.likeThumb} />
        </Link>
      </div>
      <div
        className={[
          styles.RecipeMainContainer,
          like ? styles.Like : "",
          dislike ? styles.Dislike : "",
          moveRight ? styles.MoveRight : "",
        ].join(" ")}
      >
        <div className={styles.RecipeThumbnailContainer}>
          <img
            src={recipe ? recipe.photos[0] : ""}
            className={styles.RecipeThumbnail}
          />
        </div>
        <div className={styles.RecipeInfo}>
          <h4>{recipe ? recipe.title : ""}</h4>
        </div>
      </div>
      <div className={styles.dislikeContainer}>
        <Link onClick={handleDislike}>
          <img src={dislikeThumb} className={styles.dislikeThumb} />
        </Link>
      </div>
    </div>
  );
};

export default TinderRecipeComponent;
