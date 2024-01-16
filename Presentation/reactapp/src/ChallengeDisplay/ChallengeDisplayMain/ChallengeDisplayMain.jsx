import ChallengeRowDiv from "../ChallengeRowComponent/ChallengeRowDiv";
import styles from "./ChallengeDisplayMain.module.css";
import { fetchChallenges } from "../../api/ChallengeApi";
import { useState, useEffect } from "react";

const ChallengeDisplayMain = () => {
  const [challenges, setChallenges] = useState([]);

  useEffect(() => {
    const fetchData = async () => {
      //get all challenges
      const data = await fetchChallenges();
      setChallenges(data);
    };

    fetchData();
  }, []);

  return (
    <div className={styles.ChallengeDisplayMain}>
      {challenges.map((challenge) => (
        <ChallengeRowDiv key={challenge.id} challenge={challenge} />
      ))}
    </div>
  );
};

export default ChallengeDisplayMain;
