import * as THREE from '/js/three/build/three.module.min.js';
import { STLLoader } from 'three/examples/jsm/loaders/STLLoader.js';



document.addEventListener("DOMContentLoaded", function () {
    console.log("JS is running!");

    const container = document.getElementById("threejs-container-editEM") || document.getElementById("threejs-container-switch") || document.getElementById("threejs-container-hilt")
        || document.getElementById("threejs-container-pommel") || document.getElementById("threejs-container");
/*    const container = document.getElementById("threejs-container") || document.getElementById("threejs-container-switch");*/

    
    if (!container) {
        console.error("Error: container not found.");
        return
    }
    let mesh;
    let rotation;

    const scene = new THREE.Scene();
    const camera = new THREE.PerspectiveCamera(75, 500 / 400, 0.1, 1000);
    const renderer = new THREE.WebGLRenderer();
    renderer.setSize(500, 400);


    /*document.getElementById("threejs-container").appendChild(renderer.domElement)*/

    const ambientLight = new THREE.AmbientLight(0xC0C0C0, 0.8);
    scene.add(ambientLight);

    const directionalLight = new THREE.DirectionalLight(0xCCCCCC, 1);
    directionalLight.position.set(5, 5, 5);
    scene.add(directionalLight);

    
    document.getElementById("componentSelect").addEventListener("change", function () {
        const selectedComponent = this.value;

        if (stlFiles[selectedComponent]) {
            loadModel(stlFiles[selectedComponent]);
        }

        container.appendChild(renderer.domElement);
    });

    function loadModel(modelPath) {
        if (mesh) scene.remove(mesh);

        var loader = new STLLoader();
        loader.load(modelPath, function (geometry) {
            console.log("STL file loaded.", modelPath);

            var material = new THREE.MeshPhysicalMaterial({
                color: 0xC0C0C0,
                metalness: 0.6,
                roughness: 0.5,
                clearcoat: 1.5
            }); // End material

            mesh = new THREE.Mesh(geometry, material);
            mesh.scale.set(0.06, 0.06, 0.06);
            mesh.position.set(0, 0, 3);
           
            scene.add(mesh);
            geometry.center();
            mesh.rotation.set(-Math.PI / 2, 0, 0); 

            camera.position.set(0, 0, 10);

        }); // End load

    } // End function
  

    console.log("Three.js Scene Initialized!");

    
        function animate() {
            requestAnimationFrame(animate);

            if (mesh) {

                mesh.rotation.z += 0.005;
           

              
            }            
    
            renderer.setClearColor(0x87CEEB); 
            renderer.render(scene, camera);
        }
    animate();

    });
