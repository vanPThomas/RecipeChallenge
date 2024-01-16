const fetchChallenges = async () => {
  try {
    const response = await fetch("http://localhost:5136/api/Challenge");
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const challengesData = await response.json();
    return challengesData;
  } catch (error) {
    console.error("Error fetching data:", error.message);
    return [];
  }
};

const fetchChallengeById = async (id) => {
  try {
    const response = await fetch(`http://localhost:5136/api/Challenge/${id}`);
    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const challengeData = await response.json();
    return challengeData;
  } catch (error) {
    console.error("Error fetching challenge by ID:", error.message);
    return null;
  }
};
const postChallenge = async (challengeData) => {
  try {
    console.log("Posting challenge data:", JSON.stringify(challengeData));

    const response = await fetch("http://localhost:5136/api/Challenge", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
      },
      body: JSON.stringify(challengeData),
    });

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    const responseData = await response.json();
    console.log("Challenge posted successfully:", responseData);
    return responseData;
  } catch (error) {
    console.error("Error posting challenge:", error.message);
    return null;
  }
};

const postChallengeItem = async (challengeId, itemData) => {
  try {
    console.log("Posting challenge item data:", JSON.stringify(itemData));

    const response = await fetch(
      `http://localhost:5136/api/Item?challengeId=${challengeId}`,
      {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(itemData),
      }
    );

    const responseData = await response.json();
    console.log("Server response:", responseData);

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    console.log("Challenge item posted successfully:", responseData);
    return responseData;
  } catch (error) {
    console.error("Error posting challenge item:", error.message);
    return null;
  }
};

const addVoteToItem = async (itemId) => {
  try {
    console.log("Adding vote to item:", itemId);

    const response = await fetch(
      `http://localhost:5136/api/Item?itemId=${itemId}`,
      {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
      }
    );

    const responseData = await response.json();
    console.log("Server response:", responseData);

    if (!response.ok) {
      throw new Error(`HTTP error! Status: ${response.status}`);
    }

    console.log("Vote added successfully:", responseData);
    return responseData;
  } catch (error) {
    console.error("Error adding vote to item:", error.message);
    return null;
  }
};

export {
  fetchChallenges,
  fetchChallengeById,
  postChallenge,
  postChallengeItem,
  addVoteToItem,
};
