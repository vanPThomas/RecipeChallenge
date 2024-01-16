import React, { Component } from "react";

class ColourPicker extends Component {
  constructor(props) {
    super(props);
    this.state = {
      selectedColor: "#000000", // Initial color
    };
  }

  handleColorChange = (event) => {
    const newColor = event.target.value;
    this.setState({ selectedColor: newColor });
    this.props.onColorChange(newColor);
  };

  render() {
    return (
      <div>
        <input
          type="color"
          value={this.state.selectedColor}
          onChange={this.handleColorChange}
        />
        <div
          style={{
            width: "50px",
            height: "50px",
            backgroundColor: this.state.selectedColor,
          }}
        ></div>
      </div>
    );
  }
}

export default ColourPicker;
