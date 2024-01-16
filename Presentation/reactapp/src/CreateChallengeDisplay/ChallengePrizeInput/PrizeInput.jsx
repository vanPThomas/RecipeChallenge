import React, { useState } from "react";
import styles from "./PrizeInput.module.css";

const PrizeInput = ({ onChange }) => {
  const Prizes = ["CashPrijs", "Reisje", "Auto", "JuryPlek"];
  const [addedPrizes, setAddedPrizes] = useState([]);

  const handleAddButtonClick = () => {
    // create a new prize object and add it to the addedPrizes array
    const selectedPrize = document.getElementById("PrizeSelection").value;
    if (
      selectedPrize &&
      !addedPrizes.find((prize) => prize.name === selectedPrize)
    ) {
      const prize = {
        logo: "string",
        name: selectedPrize,
        description: "string",
        company: "string",
      };
      setAddedPrizes((prevPrizes) => [...prevPrizes, prize]);
      if (onChange) {
        onChange([...addedPrizes, prize]);
      }
    }
  };

  return (
    <div className={styles.SelectorDiv}>
      <label className={styles.PrizesLabel}>Prijzen:</label>
      <div className={styles.SelectorAndButton}>
        <select id="PrizeSelection" className={styles.PrizeSelection}>
          {Prizes.map((prize, index) => (
            <option className={styles.PrizeOption} key={index} value={prize}>
              {prize}
            </option>
          ))}
        </select>
        <button className={styles.AddButton} onClick={handleAddButtonClick}>
          Add
        </button>
      </div>
      <div className={styles.PrizeCardDiv}>
        {addedPrizes.map((addedPrize, index) => (
          <div className={styles.AddedPrizeCard} key={index}>
            <span>{addedPrize.name}</span>
          </div>
        ))}
      </div>
    </div>
  );
};

export default PrizeInput;
