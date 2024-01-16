import CreateRecipeDisplay from "../CreateRecipeDisplay";
import styles from "./CreateRecipePage4.module.css";
import { Link, useLocation, useNavigate } from "react-router-dom";
import Button from "../../Button/Button";
import IngredientComponent from "./IngredientComponent/IngredientComponent";
import { useState } from "react";
import { postChallengeItem } from "../../api/ChallengeApi";

const CreateRecipePage4 = () => {
  const { search } = useLocation();
  const params = new URLSearchParams(search);
  const title = params.get("title");
  const imageUrls = [
    params.get("image1"),
    params.get("image2"),
    params.get("image3"),
  ];
  const challengeId = params.get("challengeId");

  const [ingredients, setIngredients] = useState([]);
  const [nextIngredientId, setNextIngredientId] = useState(1);

  const navigate = useNavigate();

  const handleAddIngredient = () => {
    setIngredients((prevIngredients) => [
      ...prevIngredients,
      { id: nextIngredientId, name: "", unitOfMeasurement: "" },
    ]);
    setNextIngredientId((prevId) => prevId + 1);
  };

  const handleRemoveIngredient = (id) => {
    setIngredients((prevIngredients) =>
      prevIngredients.filter((ingredient) => ingredient.id !== id)
    );
  };

  const handleIngredientChange = (id, updatedAttributes) => {
    setIngredients((prevIngredients) =>
      prevIngredients.map((ingredient) =>
        ingredient.id === id
          ? { ...ingredient, ...updatedAttributes }
          : ingredient
      )
    );
  };

  const handleNextButtonClick = async () => {
    try {
      const recipeObject = {
        parts: ingredients.map((ingredient) => ({
          name: ingredient.name,
          unitOfMeasurement: ingredient.unitOfMeasurement,
        })),
        title: title || "",
        photos: imageUrls.filter(Boolean),
      };

      console.log(challengeId);
      console.log(recipeObject);

      await postChallengeItem(challengeId, recipeObject);

      navigate("/recipe/5");
    } catch (error) {
      console.error("Error handling next button click:", error.message);
    }
  };

  return (
    <CreateRecipeDisplay>
      <div className={styles.Headers}>
        <h2>Stap 4</h2>
        <h3>Voeg de nodige ingrediënten toe!</h3>
      </div>
      <div>
        <div className={styles.IngredientsContainer}>
          {ingredients.map((ingredient) => (
            <IngredientComponent
              key={ingredient.id}
              ingredient={ingredient}
              onRemove={handleRemoveIngredient}
              onIngredientChange={handleIngredientChange}
            />
          ))}
          <button
            className={styles.addIngredientButton}
            onClick={handleAddIngredient}
          >
            +
          </button>
        </div>
      </div>
      <Button onClick={handleNextButtonClick}>Volgende</Button>
    </CreateRecipeDisplay>
  );
};

export default CreateRecipePage4;
