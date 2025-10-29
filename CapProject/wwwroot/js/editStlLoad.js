import * as THREE from '/js/three/build/three.module.min.js';
import { STLLoader } from 'three/examples/jsm/loaders/STLLoader.js';


let mesh;
document.addEventListener("DOMContentLoaded", function () {
    console.log("JS is running!");

    const container = document.getElementById("threejs-container-editEM") || document.getElementById("threejs-container-editSW") || document.getElementById("threejs-container-editHI")
        || document.getElementById("threejs-container-editPO") || document.getElementById("threejs-container");


    if (!container) {
        console.error("Error: container not found.");
        return
    } // End if

    const drop = document.getElementById("componentSelectEdit");
    if (!drop) {
        console.log("componentSelect not found.");
        return;
    } // End if

        drop.addEventListener("change", function () {
            const selectedComponent = this.value;

            if (stlFiles[selectedComponent]) {
                loadModel(stlFiles[selectedComponent]);
            }

            container.appendChild(renderer.domElement);
        }); // End event listener

    const currentSelectedComp = drop.value;
    if (stlFiles[currentSelectedComp]) {
        loadModel(stlFiles[currentSelectedComp]);
        console.log(stlFiles);
    } // End if

    // Scene details
  
    let rotation;

    const scene = new THREE.Scene();
    const camera = new THREE.PerspectiveCamera(75, 500 / 400, 0.1, 1000);
    const renderer = new THREE.WebGLRenderer();
    renderer.setSize(500, 400);


    const ambientLight = new THREE.AmbientLight(0xC0C0C0, 0.8);
    scene.add(ambientLight);

    const directionalLight = new THREE.DirectionalLight(0xC0C0C0, 1);
    directionalLight.position.set(5, 5, 5);
    scene.add(directionalLight);


   

    function loadModel(modelPath) {
        if (mesh) scene.remove(mesh);

        var loader = new STLLoader();
        loader.load(modelPath, function (geometry) {
            console.log("STL file loaded.", modelPath);

            var material = new THREE.MeshPhysicalMaterial({
                color: 0xC0C0C0,
                metalness: 0.6,
                roughness: 0.2,
                clearcoat: 1.0
            }); // End material

            mesh = new THREE.Mesh(geometry, material);
            mesh.scale.set(0.06, 0.06, 0.06);
            mesh.position.set(0, 0, 0);
            scene.add(mesh);
            geometry.center();
            camera.position.set(0, 0, 10);

        }); // End load

    } // End function


    console.log("Three.js Scene Initialized!");


    function animate() {
        requestAnimationFrame(animate);

        if (mesh) {
            mesh.rotation.y += 0.005;
        }

        renderer.setClearColor(0x87CEEB);
        renderer.render(scene, camera);
    }
    animate();

}); // End event listener
