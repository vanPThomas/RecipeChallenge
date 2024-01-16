import React, { useState } from "react";
import styles from "./IngredientComponent.module.css";
import Minus from "../../../Resource_images/Minus.svg";
import closeIcon from "../../../Resource_images/cross.svg";

const IngredientComponent = ({ ingredient, onRemove, onIngredientChange }) => {
  const {
    id,
    name: oorspronkelijkeNaam,
    unitOfMeasurement: oorspronkelijkeHoeveelheid,
  } = ingredient;

  const [naam, setNaam] = useState(oorspronkelijkeNaam || "");
  const [hoeveelheid, setHoeveelheid] = useState(
    oorspronkelijkeHoeveelheid || ""
  );

  const handleCloseClick = () => {
    onRemove(ingredient.id);
  };
  const handleNameChange = (e) => {
    const nieuweNaam = e.target.value;
    setNaam(nieuweNaam);
    onIngredientChange(id, { name: nieuweNaam });
  };
  const handleAmountChange = (e) => {
    const nieuweHoeveelheid = e.target.value;
    setHoeveelheid(nieuweHoeveelheid);
    onIngredientChange(id, { unitOfMeasurement: nieuweHoeveelheid });
  };
  return (
    <>
      <div className={styles.MainContainer}>
        <div className={styles.IngredientDash}>
          <img src={Minus} className={styles.Minus} alt="Minus" />
        </div>
        <label className={styles.Label}>Ingrediënt</label>
        <div className={styles.NameInputContainer}>
          <input
            className={styles.NameInput}
            value={naam}
            onChange={handleNameChange}
          />
        </div>
        <label className={styles.Label}>Hoeveelheid</label>
        <div className={styles.AmountInputContainer}>
          <input
            className={styles.AmountInput}
            value={hoeveelheid}
            onChange={handleAmountChange}
          />
        </div>
        <div className={styles.closeButtonContainer}>
          <button className={styles.closeButton} onClick={handleCloseClick}>
            <img className={styles.closeIcon} src={closeIcon} alt="Close" />
          </button>
        </div>
      </div>
    </>
  );
};

export default IngredientComponent;
