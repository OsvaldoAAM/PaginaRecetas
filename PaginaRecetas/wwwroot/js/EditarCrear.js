$(document).ready(function () {
    // Editar Título
    $(".edit-title").click(function () {
        const currentTitle = $(".recipe-title").text();
        const newTitle = prompt("Edita el título:", currentTitle);
        if (newTitle) {
            $(".recipe-title").text(newTitle);
        }
    });

    // Editar Descripción
    $(".edit-description").click(function () {
        const currentDescription = $(".recipe-description").text();
        const newDescription = prompt("Edita la descripción:", currentDescription);
        if (newDescription) {
            $(".recipe-description").text(newDescription);
        }
    });

    // Cambiar Imagen
    $(".edit-image").click(function () {
        $("#upload-image").trigger("click");
    });

    $("#upload-image").change(function () {
        const file = this.files[0];
        if (file) {
            const reader = new FileReader();
            reader.onload = function (e) {
                $(".recipe-image img").attr("src", e.target.result);
            };
            reader.readAsDataURL(file);
        }
    });

    // Editar Tiempo
    $(".edit-time").click(function () {
        const currentTime = $(".recipe-time").text();
        const newTime = prompt("Edita el tiempo de preparación:", currentTime);
        if (newTime) {
            $(".recipe-time").text(newTime);
        }
    });

    // Editar Dificultad
    $(".edit-difficulty").click(function () {
        const currentDifficulty = $(".difficulty-indicator").data("level") || "Fácil";
        const newDifficulty = prompt("Edita la dificultad (Fácil, Medio, Difícil):", currentDifficulty);
        if (newDifficulty) {
            $(".difficulty-indicator").text(newDifficulty);
            $(".difficulty-indicator").data("level", newDifficulty);
        }
    });

    // Añadir Ingrediente
    $(".add-ingredient").click(function () {
        const newIngredient = prompt("Nuevo ingrediente:");
        if (newIngredient) {
            $(".ingredients ul").append(`<li>${newIngredient} <span class="delete-ingredient">🗑</span></li>`);
        }
    });

    // Eliminar Ingrediente
    $(document).on("click", ".delete-ingredient", function () {
        $(this).parent().remove();
    });

    // Añadir Paso
    $(".add-step").click(function () {
        const newStep = prompt("Nuevo paso de preparación:");
        if (newStep) {
            $(".preparation ul").append(`<li>${newStep} <span class="delete-step">🗑</span></li>`);
        }
    });

    // Eliminar Paso
    $(document).on("click", ".delete-step", function () {
        $(this).parent().remove();
    });

    // Guardar Receta
    $(".btn-save").click(function () {
        const recipe = {
            title: $(".recipe-title").text(),
            description: $(".recipe-description").text(),
            image: $(".recipe-image img").attr("src"),
            time: $(".recipe-time").text(),
            difficulty: $(".difficulty-indicator").data("level"),
            ingredients: $(".ingredients ul li").map(function () {
                return $(this).text().replace("🗑", "").trim();
            }).get(),
            steps: $(".preparation ul li").map(function () {
                return $(this).text().replace("🗑", "").trim();
            }).get(),
        };

        const recipeListKey = "publishedRecipes";
        let recipes = JSON.parse(localStorage.getItem(recipeListKey)) || [];
        const recipeId = new URLSearchParams(window.location.search).get("id");

        if (recipeId) {
            recipes[recipeId] = recipe; // Actualiza receta existente
        } else {
            recipes.push(recipe); // Añade nueva receta
        }

        localStorage.setItem(recipeListKey, JSON.stringify(recipes));
        alert("Receta guardada exitosamente.");
        window.location.href = "/Cuenta/RecetasPublicadas";
    });

    // Cancelar
    $(".btn-cancel").click(function () {
        window.location.href = "/Cuenta/RecetasPublicadas";
    });
});