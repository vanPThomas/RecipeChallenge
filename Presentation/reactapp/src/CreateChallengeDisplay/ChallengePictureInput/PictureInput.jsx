import React, { useState } from "react";
import ImageUploader from "../../ImageUploader/ImageUploader";
import styles from "./PictureInput.module.css";

const PictureInput = (props) => {
  const { onChange } = props;

  const handleImageChange = (newImage) => {
    if (onChange) {
      onChange(newImage);
    }
  };

  return (
    <div className={styles.PictureInputDiv}>
      <label className={styles.Label} htmlFor="PictureInput">
        Afbeelding:
      </label>
      <ImageUploader onChange={handleImageChange} />
    </div>
  );
};

export default PictureInput;
