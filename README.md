# 🔷 Hex Grid Generator (Hexagonal Tile Map)

![Project Status](https://img.shields.io/badge/Status-Completed-success) 
![License](https://img.shields.io/badge/License-MIT-blue)
![Unity Version](https://img.shields.io/badge/Unity-2022.3%20LTS-black)

**A utility developed for generating a Procedural Hexagonal Grid map within the Unity environment.** This project implements the core mathematical and coding foundations of the hexagonal map structure commonly used in strategy, simulation, and roguelike games.

---

## 💡 Key Features

This tool covers the essential functionalities required for working with hexagonal maps:

* **Procedural Generation:** Automated placement of hexagonal tiles (hexes) in the scene based on user-defined width and height parameters.
* **Coordinate System:** Uses the **Offset Coordinate System** (or the specific system used in your project) to ensure tiles are positioned mathematically correct.
* **Neighborhood Relations:** Efficient and accurate determination of the **6 neighboring tiles** for any given hex.
* **Visualization:** Utilizes debug text (Text Mesh Pro) to display the position and coordinates of each tile.

---

## ⚙️ Technical Details

| Area | Detail |
| :--- | :--- |
| **Game Engine** | Unity 2022.3 LTS (or your project version) |
| **Programming Language**| C# |
| **Focus Area** | Data Structures, Algorithms, Procedural Generation |
| **Libraries Used** | TextMesh Pro (Used for visualizing tile coordinates.) |
| **Developer Role** | **(EDIT THIS)** I coded all the grid mathematics and implemented the Unity Editor tools myself. |

### 📐 Implemented Mathematical Concepts

The project focuses on **Position to Coordinate Conversion**, which is one of the key challenges of hexagonal grid geometry. This involves mapping screen-space World Positions back to the correct Hex Coordinates.

---

## 🛠️ Installation and Usage

To run the project on your local machine and use the tool:

1.  **Clone the Repository:**
    ```bash
    git clone [https://github.com/glshryldrm/HexGridGenerator.git](https://github.com/glshryldrm/HexGridGenerator.git)
    ```
2.  **Open in Unity:** Open the project via the Unity Hub. The required Unity version (specified above) should load automatically.
3.  **Load Generator Script:** Attach the main `HexGridGenerator` script to an empty GameObject in your scene.
4.  **Set Parameters:** In the Inspector panel, set your desired `Width` and `Height` values.
5.  **Generate Grid:** The grid will be generated automatically when you press the 'Play' button in the Unity Editor (or if you used a custom Editor button, mention that here).

---

## 🔗 Contact & Portfolio

* **Gülseher Yıldırım (Developer)**
* **LinkedIn:** [https://linkedin.com/in/glshryldrm](https://linkedin.com/in/glshryldrm)
* **GitHub:** [https://github.com/glshryldrm](https://github.com/glshryldrm)
* **Email:** glshryldrm@gmail.com

---

## 📜 License

This project is licensed under the MIT License. See the [LICENSE.txt](LICENSE.txt) file for details.
