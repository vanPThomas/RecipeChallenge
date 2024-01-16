import React, { useState } from "react";
import InputField from "../InputField/InputField";
import DescriptionInput from "./ChallengeDescriptionInput/DescriptionInput";
import PictureInput from "./ChallengePictureInput/PictureInput";
import PrizeInput from "./ChallengePrizeInput/PrizeInput";
import styles from "./CreateChallengeDisplay.module.css";
import Button from "../Button/Button";
import { postChallenge } from "../api/ChallengeApi";

const CreateChallengeDisplay = () => {
  const [challengeData, setChallengeData] = useState({
    //use usestate to create challenge data and keep it up to date
    name: "",
    description: "",
    defaultPicture: "",
    prizes: [
      {
        logo: "",
        name: "",
        description: "",
        company: "",
      },
    ],
    month: 0,
  });

  const handleInputChange = (fieldName, value) => {
    // update challenge data when there is a change in one of the fields
    setChallengeData((prevData) => ({
      ...prevData,
      [fieldName]: value,
    }));
  };

  const handleSubmit = async () => {
    // challenge data is sent to be posted, check fields before posting
    try {
      if (challengeData.name.trim() === "") {
        alert("Name field should be filled in!!");
        return;
      }
      if (challengeData.month === "") {
        alert("Month field should be filled in!!");
        return;
      }
      const month = parseInt(challengeData.month, 10);
      if (isNaN(month) || month < 1 || month > 12) {
        alert("Month should be a number between 1 and 12!!");
        return;
      }
      if (challengeData.description.trim() === "") {
        alert("Description field should be filled in!!");
        return;
      }
      if (challengeData.defaultPicture.trim() === "") {
        alert("Default Picture field should be filled in!!");
        return;
      }
      if (
        challengeData.prizes.some(
          (prize) =>
            prize.name.trim() === "" ||
            prize.description.trim() === "" ||
            prize.company.trim() === ""
        )
      ) {
        alert("Prize field should be filled in!!");
        return;
      }
      console.log(challengeData);
      const response = await postChallenge(challengeData);

      console.log("Success:", response);
    } catch (error) {
      console.error("Error:", error);
    }
  };

  return (
    <div className={styles.CreateChallengeDisplay}>
      <div className={styles.CreateChallengeDisplay}>
        <h1>Maak een challenge aan!</h1>
        <InputField
          label="Naam"
          onChange={(textareaValue) => handleInputChange("name", textareaValue)}
        >
          Naam
        </InputField>
        <InputField
          label="Month"
          onChange={(textareaValue) =>
            handleInputChange("month", textareaValue)
          }
        >
          Maand
        </InputField>
        <DescriptionInput
          onChange={(descriptionValue) =>
            handleInputChange("description", descriptionValue)
          }
        />
        <PictureInput
          onChange={(uploadedImage) =>
            handleInputChange("defaultPicture", uploadedImage)
          }
        />
        <PrizeInput
          onChange={(addedPrizes) => handleInputChange("prizes", addedPrizes)}
        />
        <Button type="button" onClick={handleSubmit}>
          Bevestig
        </Button>
      </div>
    </div>
  );
};

export default CreateChallengeDisplay;
