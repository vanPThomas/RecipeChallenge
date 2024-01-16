import React, { useCallback, useState } from "react";
import { useDropzone } from "react-dropzone";
import styles from "./ImageUploader.module.css";

const ImageUploader = () => {
  const [uploadedImage, setUploadedImage] = useState(null);

  const onDrop = useCallback((acceptedFiles, rejectedFiles, event) => {
    const items = event.dataTransfer.items;

    for (let i = 0; i < items.length; i++) {
      // Check if the item is a URL
      if (items[i].kind === "string" && items[i].type === "text/plain") {
        items[i].getAsString((url) => {
          // Set the URL as uploadedImage
          setUploadedImage(url);
        });
        break;
      }
    }
  }, []);

  const { getRootProps, getInputProps } = useDropzone({ onDrop });

  return (
    <div>
      <div {...getRootProps()} className={styles.dropzoneStyles}>
        <input {...getInputProps()} />
        <p>Drag and drop an image here, or click to select one</p>
      </div>
      {uploadedImage && (
        <div>
          <p>Geselecteerde afbeelding:</p>
          <img
            src={uploadedImage}
            alt="Uploaded"
            className={styles.imageStyles}
          />
        </div>
      )}
    </div>
  );
};

export default ImageUploader;
