import React, { useState } from "react";
import CreateRecipeDisplay from "../CreateRecipeDisplay";
import styles from "./CreateRecipePage3.module.css";
import { Link, useLocation } from "react-router-dom";
import Button from "../../Button/Button";
import ImageUploader from "../../ImageUploader/ImageUploader";

const CreateRecipePage3 = () => {
  const { search } = useLocation();
  const params = new URLSearchParams(search);
  const name = params.get("name");
  const email = params.get("email");
  const title = params.get("title");
  const challengeId = params.get("challengeId");

  const [imageUrls, setImageUrls] = useState(["", "", ""]);

  const handleImageChange = (index, url) => {
    const updatedImageUrls = [...imageUrls];
    updatedImageUrls[index] = url;
    setImageUrls(updatedImageUrls);
  };

  return (
    <CreateRecipeDisplay>
      <div className={styles.Headers}>
        <h2>Stap 3</h2>
        <h3>Voeg jouw 3 mooiste afbeeldingen van je recept toe!</h3>
      </div>
      <div className={styles.ImageUploader}>
        <div className={styles.SingleImageUploaderDiv}>
          <ImageUploader onChange={(url) => handleImageChange(0, url)} />
        </div>
        <div className={styles.SingleImageUploaderDiv}>
          <ImageUploader onChange={(url) => handleImageChange(1, url)} />
        </div>
        <div className={styles.SingleImageUploaderDiv}>
          <ImageUploader onChange={(url) => handleImageChange(2, url)} />
        </div>
      </div>
      <div className={styles.Spacer}></div>
      <Link
        to={`/recipe/4?name=${name}&email=${email}&title=${title}&challengeId=${challengeId}&image1=${imageUrls[0]}&image2=${imageUrls[1]}&image3=${imageUrls[2]}`}
      >
        <Button>Volgende</Button>
      </Link>
    </CreateRecipeDisplay>
  );
};

export default CreateRecipePage3;
